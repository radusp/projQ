using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Drawing;
using QR_Project_BL.Interfaces;
namespace QR_Project_BL
{
    public class ImageQueue : IimageQueue
    {
        private readonly BlockingCollection<Bitmap> _queue
            = new BlockingCollection<Bitmap>(new ConcurrentBag<Bitmap>());
        private ImageAnalyzer frameAnalyzer;

        public ImageQueue(ImageAnalyzer frame)
        {
            frameAnalyzer = frame;
        }

        public int getQueueCount()
        {
            return _queue.Count;
        }

        public void AddFrame(Bitmap transaction)
        {
            _queue.Add(transaction);
        }

        public void CompleteAdding()
        {
            _queue.CompleteAdding();
        }

        public void processImagesFromQueue()
        {
            while (true)
            {
                try
                {
                    Bitmap nextFrame = _queue.Take();
                    frameAnalyzer.analyzeAllImages(nextFrame);                    
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    frameAnalyzer.doWhenAllQueueWasProcessed();
                    return;
                }
            }
        }
    }
}
