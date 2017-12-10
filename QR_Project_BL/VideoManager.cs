using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Accord.Video.FFMPEG;
using System.Drawing;
using QR_Project_BL.Interfaces;
using System.Threading;

namespace QR_Project_BL
{
    public class VideoManager : Interfaces.IVideoManager
    {
        private VideoFileReader videoReader = new VideoFileReader();      
        private bool isTheVideoLoaded = false;
        private IimageQueue workQueue;
        private  int maxQueueSize = 1000;
        private  int threadSleepTimeInMsIfQueueIsFull = 1000;

        public VideoManager(IimageQueue myQueue)
        {
            workQueue = myQueue;
        }

        public bool isVideoLoaded()
        {
            return isTheVideoLoaded; 
        }

        public void setForTestIsVideoLOaded(bool value) { isTheVideoLoaded = value; }
        public void extractFramesFromVideo()
        {
            extractFramePreValidation();
            extractFrame();
        }

        private void extractFrame()
        {
            for (int i = 0; i < videoReader.FrameCount; i++)
            {
                try
                {                    
                    if (workQueue.getQueueCount() < maxQueueSize)
                    {
                        workQueue.AddFrame(videoReader.ReadVideoFrame(i));
                    }
                    else
                    {
                        Thread.Sleep(threadSleepTimeInMsIfQueueIsFull);
                        i = i - 1;
                    }
                    
                }
                catch (ArgumentException ex)
                {
                    string debugString = ex.ToString() ;
                }
            }
        }

        private void extractFramePreValidation()
        {
            if (!isTheVideoLoaded)
                throw new ExtractFramesWhenNoVideoWasLoaded();
            if (videoReader.FrameCount == 0)
                throw new FrameCountOFLoadedVideoIsZero();
        }

        public void loadVideo(string vPath)
        {
            validateVideoPath(vPath);
            try
            {
                videoReader.Open(vPath);
                isTheVideoLoaded = true;
            }
            catch (Exception)
            {
                throw new NotAbleToLoadVideoFile();
            }        
        }

        private static void validateVideoPath(string vPath)
        {
            if (vPath == "")
                throw new EmptyPathSpecifiedWhenLoadingVideo();
            if (vPath == null)
                throw new NullPathToVideoException();
            if (!File.Exists(vPath))
                throw new PathToVideoFileDoesNotExistException();
        }
    }

    public class EmptyPathSpecifiedWhenLoadingVideo : Exception { }
    public class PathToVideoFileDoesNotExistException : Exception { }
    public class NullPathToVideoException : Exception { }
    public class NotAbleToLoadVideoFile : Exception { }
    public class ExtractFramesWhenNoVideoWasLoaded : Exception { }
    public class FrameCountOFLoadedVideoIsZero : Exception { }
}
