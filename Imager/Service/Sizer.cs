using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imager.Service
{
    static class Sizer
    {
        public static void Widen(string img, int width, string outputFormat = null, string targetPath = null)
        {
            Image srcImg = Image.FromFile(@img);
            Bitmap dstImg = Resize(srcImg, 100, 100);
            dstImg.Save(@targetPath);
        }

        public static void Heighten(string img, int height, string outputFormat = null, string targetPath = null) {}

        public static void Maximize(string img, int width, int height, string outputFormat = null, string targetPath = null) {}

        public static void Thumbnail(string img, int width, int height, string outputFormat = null, string targetPath = null) {}

        private static Bitmap Resize(Image img, int width, int height)
        {
            var rect = new Rectangle(0, 0, width, height);
            var destImg = new Bitmap(width, height);

            destImg.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImg))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImg;
        }
    }
}
