using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Accord.Video.FFMPEG;
using System.Drawing;
using QR_Project_BL.Interfaces;

namespace QR_Project_BL
{
    public class VideoManager : Interfaces.IVideoManager
    {
        private VideoFileReader videoReader = new VideoFileReader();
        private List<Bitmap> allVideoFrames = new List<Bitmap>();
        private bool isTheVideoLoaded = false;
        private bool isListOfFramesPopulated = false;

        public bool isVideoLoaded()
        {
            return isTheVideoLoaded; 
        }
        public bool isListFramesPopulated()
        {
           return isListOfFramesPopulated; 
        }
        public void setForTestIsVideoLOaded(bool value) { isTheVideoLoaded = value; }
        public void setForTestisListOfFramesPopulated(bool value) { isListOfFramesPopulated = value; }
        public void extractFramesFromVideo()
        {
            extractFramePreValidation();
            extractFrame();
            extractFramePostValidation();
        }

        private void extractFrame()
        {
            for (int i = 2500; i < videoReader.FrameCount; i++)
            {
                try
                {
                    allVideoFrames.Add(videoReader.ReadVideoFrame(i));
                }
                catch (ArgumentException)
                {
                    string a = "";
                }
            }
        }
        private void extractFramePostValidation()
        {
            if (allVideoFrames.Count < 1)
            {
                isListOfFramesPopulated = true;
                throw new NoFramesExtractedInListFromVideo();
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

        List<Bitmap> IVideoManager.getFramesExtracted()
        {
            return allVideoFrames;
        }
    }

    public class EmptyPathSpecifiedWhenLoadingVideo : Exception { }
    public class PathToVideoFileDoesNotExistException : Exception { }
    public class NullPathToVideoException : Exception { }
    public class NotAbleToLoadVideoFile : Exception { }
    public class ExtractFramesWhenNoVideoWasLoaded : Exception { }
    public class FrameCountOFLoadedVideoIsZero : Exception { }
    public class NoFramesExtractedInListFromVideo : Exception { }



}
