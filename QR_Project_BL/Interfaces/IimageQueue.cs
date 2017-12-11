using System.Drawing;

namespace QR_Project_BL.Interfaces
{
    public interface IimageQueue
    {
        void AddFrame(Bitmap transaction);
        void CompleteAdding();
        int getQueueCount();
        void processImagesFromQueue();
    }
}