using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Project_BL.Interfaces
{
    public interface IVideoManager
    {
        void loadVideo(string path);
        void extractFramesFromVideo();
        List<Bitmap> getFramesExtracted();
    }
}
