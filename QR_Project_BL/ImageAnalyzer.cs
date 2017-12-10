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
        public ImageAnalyzer()
        {
        }

        public void analyzeAllImages(Bitmap frame)
        {             
            LuminanceSource source;
            source = new BitmapLuminanceSource(frame);
            BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
            Result res = new MultiFormatReader().decode(bitmap);
            if (res != null)
            {
                Console.WriteLine(res.Text);
            }
        }
    }
}
