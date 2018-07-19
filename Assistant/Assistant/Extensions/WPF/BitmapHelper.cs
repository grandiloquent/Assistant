using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows;

namespace Helpers
{
    static class BitmapHelper
    {

        public static void SaveVisualToImage(string filename, FrameworkElement visual, double dpi = 96)
        {
            RenderTargetBitmap bmpRen = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, dpi, dpi, PixelFormats.Pbgra32);
            bmpRen.Render(visual);

            FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
            JpegBitmapEncoder encoder = new JpegBitmapEncoder
            {
                QualityLevel = 95
            };
            encoder.Frames.Add(BitmapFrame.Create(bmpRen));
            encoder.Save(stream);

            stream.Dispose();


        }
    }
}
