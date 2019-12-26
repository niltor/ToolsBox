using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Primitives;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Image = SixLabors.ImageSharp.Image;

namespace ImageHelper
{
    public class ImageProcess
    {
        public ImageProcess()
        {

        }

        /// <summary>
        /// resize图片
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="outputPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void ResizeImage(Stream stream, string outputPath, int width, int height)
        {
            using (var image = Image.Load(stream))
            {
                image.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Size = new SixLabors.Primitives.Size(width, height),
                        Mode = ResizeMode.Max,
                    }));
                image.Save(outputPath); // Automatic encoder selected based on extension.
            }
        }


        public void AddWatermark(Stream stream)
        {
            var watermarkedStream = new MemoryStream();
            using (var img = System.Drawing.Image.FromStream(stream))
            {
                using (var graphic = Graphics.FromImage(img))
                {
                    var font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold, GraphicsUnit.Pixel);
                    var color = System.Drawing.Color.FromArgb(128, 255, 255, 255);
                    var brush = new SolidBrush(color);
                    var point = new System.Drawing.Point(img.Width - 120, img.Height - 30);

                    graphic.DrawString("Test", font, brush, point);
                    img.Save(watermarkedStream, ImageFormat.Png);
                }
            }
        }
        public void AddWatermark(Stream stream, string logoPath)
        {
            var watermarkedStream = new MemoryStream();
            using (var img = System.Drawing.Image.FromStream(stream))
            {
                using (var graphic = Graphics.FromImage(img))
                {
                    var font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold, GraphicsUnit.Pixel);
                    var color = System.Drawing.Color.FromArgb(128, 255, 255, 255);
                    var brush = new SolidBrush(color);
                    var point = new System.Drawing.Point(img.Width - 120, img.Height - 30);

                    graphic.DrawString("Test", font, brush, point);
                    using (var logoImg = System.Drawing.Image.FromFile(logoPath))
                    {
                        graphic.DrawImage(logoImg, point);
                    }
                    img.Save(watermarkedStream, ImageFormat.Png);
                }
            }
        }
    }
}
