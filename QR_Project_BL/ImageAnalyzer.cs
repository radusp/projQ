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
        private List<Result> foundQrCodesList = new List<Result>();
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
                foundQrCodesList.Add(decodeingResult);
            }
        }

        public void doWhenAllQueueWasProcessed()
        {
            if (foundQrCodesList.Count > 0)
            {
                string doTheOtherStuff = "asda";
            }
        }
    }
}
