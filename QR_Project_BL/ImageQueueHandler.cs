using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Project_BL
{
    public class ImageQueueHandler
    {
        private ImageAnalyzer _imgAnalyzer;
        private ImageQueue _imgQueue;
        private VideoManager _videoManager;
        private VideoInfo _videoInfo;
        private ReportCreator _raportCreator;
        private string pathReport = "";

        public ImageQueueHandler(string pathVideo, string pathToReportFile)
        {
            _imgAnalyzer = new ImageAnalyzer();
            _imgQueue = new ImageQueue(_imgAnalyzer);
            _videoManager = new VideoManager(_imgQueue);
            _videoManager.loadVideo(pathVideo);
            pathReport = pathToReportFile;
        }

        public void startAnalysisOnThreads()
        {
            Task t1 = Task.Run(() => _videoManager.extractFramesFromVideo());
            Task t2 = Task.Run(() => _imgQueue.processImagesFromQueue());

            Task.WaitAll(t1);
            _imgQueue.CompleteAdding();
            Task.WaitAll(t2);
            _videoInfo = _videoManager.getVideoInfo();
            createReport();
        }

        private void createReport()
        {
            _raportCreator = new ReportCreator(_videoInfo, _imgAnalyzer.getAnalysisResults());
            _raportCreator.generateReport(pathReport);
        }
    }
}
