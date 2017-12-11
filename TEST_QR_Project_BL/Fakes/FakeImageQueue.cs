using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QR_Project_BL.Interfaces;
using System.Drawing;


namespace TEST_QR_Project_BL.Fakes
{
    public class FakeImageQueue : IimageQueue
    {
        
        public void AddFrame(Bitmap transaction)
        {
            throw new NotImplementedException();
        }

        public void CompleteAdding()
        {
            throw new NotImplementedException();
        }

        public int getQueueCount()
        {
            throw new NotImplementedException();
        }

        public void processImagesFromQueue()
        {
            throw new NotImplementedException();
        }
    }

}
