using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QR_Project_BL.Interfaces;
using ZXing.QrCode;
using System.Drawing;
using ZXing;
using ZXing.Common;

namespace QR_Project_BL
{
    public class ImageAnalyzer
    {
        private Dictionary<Result, int> foundQrCodesList = new Dictionary<Result,int>();
        private int frameIndex = 0;
        public ImageAnalyzer()
        {
        }

        public void analyzeAllImages(Bitmap frame)
        {             
            LuminanceSource source = new BitmapLuminanceSource(frame);
            BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
            Result decodeingResult = new MultiFormatReader().decode(bitmap);
            if (decodeingResult != null)
            {
                foundQrCodesList.Add(decodeingResult, frameIndex);
            }
            frameIndex++;
        }

        public void doWhenAllQueueWasProcessed()
        {
            if (foundQrCodesList.Count > 0)
            {
                string debugPoint = "debug";
            }
        }

        public Dictionary<Result, int> getAnalysisResults()
        {
            if (foundQrCodesList.Count > 0)
            {
                return foundQrCodesList;
            }
            else
            {
                return null;
            }
            
        }
    }
}
