using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QR_Project_BL;
using TEST_QR_Project_BL.Fakes;

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
            FakeImageQueue fakeQueue = new FakeImageQueue();
            VideoManager myManager = new VideoManager(fakeQueue);
            //Act
            myManager.loadVideo("");
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(PathToVideoFileDoesNotExistException))]
        public void pathThatDoesNotExistWillThrowCustomException()
        {
            //Arrange
            FakeImageQueue fakeQueue = new FakeImageQueue();
            VideoManager myManager = new VideoManager(new ImageQueue(null));
            //Act
            myManager.loadVideo(@"O:\zzz.avi");
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(NullPathToVideoException))]
        public void nullPathToVideoFIleWillThrowCustomException()
        {
            //Arrange
            FakeImageQueue fakeQueue = new FakeImageQueue();
            VideoManager myManager = new VideoManager(new ImageQueue(null));
            //Act
            myManager.loadVideo(null);
            //Assert
        }
        [TestMethod]
        public void IfAbleToLoadVideoSetSuccessFlagToTrue()
        {
            //Arrange
            FakeImageQueue fakeQueue = new FakeImageQueue();
            VideoManager myManager = new VideoManager(fakeQueue);
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
            FakeImageQueue fakeQueue = new FakeImageQueue();
            VideoManager myManager = new VideoManager(fakeQueue);
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
            FakeImageQueue fakeQueue = new FakeImageQueue();
            VideoManager myManager = new VideoManager(fakeQueue);
            //Act
            myManager.loadVideo(@"C:\sample.wmv");
            myManager.extractFramesFromVideo();
            //Assert
        }
    }
}
