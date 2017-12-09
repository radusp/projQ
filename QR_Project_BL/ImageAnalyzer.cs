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
        IVideoManager receivedVideo;
        public ImageAnalyzer(IVideoManager videoObject)
        {
            receivedVideo = videoObject;
        }

        public void analyzeAllImages()
        {
            List<string> resultedText = new List<string>();  
            foreach (Bitmap bmp in receivedVideo.getFramesExtracted())
            {
                LuminanceSource source;
                source = new BitmapLuminanceSource(bmp);
                BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
                Result res = new MultiFormatReader().decode(bitmap);
                if (res != null)
                {
                    resultedText.Add(res.Text);
                }
            }
        }

        public void getOneImage()
        {
            Image testImg = Image.FromFile(@"D:\qr.png");
            Bitmap input = new Bitmap(testImg); 



        }
    }
}
