using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;

namespace Helpers
{
   static class ImageHelper
    {
        private static void SaveJpegWithCompressionSetting(Image image, string fileName, long compression)
        {
            var eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(Encoder.Quality, compression);
            var ici = GetEncoderInfo("image/jpeg");
            image.Save(fileName, ici, eps);
        }
        public static void SaveJpegWithCompression(this Image image, string fileName, long compression)
        {
            SaveJpegWithCompressionSetting(image, fileName, compression);
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            var encoders = ImageCodecInfo.GetImageEncoders();
            return encoders.FirstOrDefault(t => t.MimeType == mimeType);
        }
        public static Bitmap GetBitmap(int width, int height)
        {
            return new Bitmap(width, height);
        }
    }
}
