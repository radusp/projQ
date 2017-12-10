using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QR_Project_BL;

namespace TEST_QR_Project_BL
{
    [TestClass]
    public class VideoManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(EmptyPathSpecifiedWhenLoadingVideo))]
        public void emptyPathToVideoReceivedThrowError()
        {
            //Arrange
            VideoManager myManager = new VideoManager();
            //Act
            myManager.loadVideo("");
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(PathToVideoFileDoesNotExistException))]
        public void pathThatDoesNotExistWillThrowCustomException()
        {
            //Arrange
            VideoManager myManager = new VideoManager();
            //Act
            myManager.loadVideo(@"O:\zzz.avi");
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(NullPathToVideoException))]
        public void nullPathToVideoFIleWillThrowCustomException()
        {
            //Arrange
            VideoManager myManager = new VideoManager();
            //Act
            myManager.loadVideo(null);
            //Assert
        }
        [TestMethod]
        public void IfAbleToLoadVideoSetSuccessFlagToTrue()
        {
            //Arrange
            VideoManager myManager = new VideoManager();
            //Act
            myManager.loadVideo(@"C:\test.mp4");
            //Assert
            Assert.AreEqual(myManager.isVideoLoaded(), true);
        }

        [TestMethod]
        [ExpectedException(typeof(ExtractFramesWhenNoVideoWasLoaded))]
        public void TryingToExtractWhenNoVideoIsLoadedWillThrowError()
        {
            //Arrange
            VideoManager myManager = new VideoManager();
            //Act
            myManager.loadVideo(@"C:\test.mp4");
            myManager.setForTestIsVideoLOaded(false);
            myManager.extractFramesFromVideo();
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(FrameCountOFLoadedVideoIsZero))]
        public void IfFrameCountOfLoadedVideoIsZeroThrowCustomException()
        {
            //Arrange
            VideoManager myManager = new VideoManager();
            //Act
            myManager.loadVideo(@"C:\sample.wmv");
            myManager.extractFramesFromVideo();
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(NoFramesExtractedInListFromVideo))]
        public void IfNoFramesAreINListThrowCustomException()
        {
            //Arrange
            VideoManager myManager = new VideoManager();
            //Act
            myManager.loadVideo(@"C:\test.mp4");
            myManager.extractFramesFromVideo();
            myManager.setForTestisListOfFramesPopulated(false);
            //Assert
        }
    }
}
