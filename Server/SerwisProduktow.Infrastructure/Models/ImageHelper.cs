using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Infrastructure.Models
{
    public static class ImageHelper
    {

        public static string WriteImage(string base64Image, string savePath)
        {
            var x = base64Image.Split(',').Last();
            byte[] arr = Convert.FromBase64String(x);

            var filename = $@"{DateTime.Now.Ticks}";

            using (var im = Image.FromStream(new MemoryStream(arr)))
            {
                ImageFormat frmt;
                if (ImageFormat.Png.Equals(im.RawFormat))
                {
                    filename += ".png";
                    frmt = ImageFormat.Png;
                }
                else
                {
                    filename += ".jpg";
                    frmt = ImageFormat.Jpeg;
                }

                var image = Resize(im, 250, 250, false);

                string path = savePath + @"\" +filename;
                image.Save(path, frmt);
                return filename;
            }

        }

        public static Image Resize(Image image, int newWidth, int newHeight, bool onlyResizeIfWider)
        {
            if (onlyResizeIfWider && image.Width <= newWidth) newWidth = image.Width;

            var res = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(res))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return res;
        }
    }
}
