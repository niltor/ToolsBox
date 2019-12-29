using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Primitives;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        /// <summary>
        /// 添加文字
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public Stream AddWatermark(Stream stream)
        {
            var watermarkedStream = new MemoryStream();
            using (var img = System.Drawing.Image.FromStream(stream))
            {
                using (var graphic = Graphics.FromImage(img))
                {
                    var font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold, GraphicsUnit.Pixel);
                    var color = System.Drawing.Color.FromArgb(128, 255, 255, 255);
                    var brush = new SolidBrush(color);
                    var point = new System.Drawing.Point(img.Width - 120, img.Height - 30);

                    graphic.DrawString("Test", font, brush, point);
                    img.Save(watermarkedStream, ImageFormat.Png);
                }
            }
            return watermarkedStream;

        }

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="logoPath">被添加的图片相对地址</param>
        /// <param name="position">位置</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="padding">边距</param>
        /// <returns></returns>
        public Stream AddWatermark(Stream stream, string logoPath, Position position = Position.BottomRight, int width = 100, int height = 40, int padding = 4)
        {
            var watermarkedStream = new MemoryStream();
            using (var img = System.Drawing.Image.FromStream(stream))
            {
                // 确定位置
                int px = 0;
                int py = 0;
                switch (position)
                {
                    case Position.TopLeft:
                        px = width + padding;
                        py = height + padding;
                        break;
                    case Position.TopRight:
                        py = height + padding;
                        px = img.Width - width - padding;
                        break;
                    case Position.BottomLeft:
                        px = width + padding;
                        py = img.Height - (height + padding);
                        break;
                    case Position.BottomRight:
                        py = img.Height - (height + padding);
                        px = img.Width - width - padding;
                        break;
                    default:
                        break;
                }

                // 处理被添加的水印资源 
                using (FileStream pngStream = new FileStream("test.png", FileMode.Open, FileAccess.Read))
                using (var logoImg = System.Drawing.Image.FromFile(logoPath))
                {
                    var resized = new Bitmap(width, height);
                    using (var graphics = Graphics.FromImage(resized))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighSpeed;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.CompositingMode = CompositingMode.SourceCopy;
                        graphics.DrawImage(logoImg, 0, 0, width, height);
                        resized.Save($"resized-temp.png", ImageFormat.Png);
                    }
                    using (var graphic = Graphics.FromImage(img))
                    {
                        var point = new System.Drawing.Point(px, py);
                        graphic.DrawImage(resized, point);
                        img.Save(watermarkedStream, ImageFormat.Png);
                    }
                }
                return watermarkedStream;
            }
        }
    }
    /// <summary>
    /// 位置
    /// </summary>
    public enum Position
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}