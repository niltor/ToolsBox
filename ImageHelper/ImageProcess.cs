using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
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
                image.Mutate(img => img
                    .Resize(new ResizeOptions
                    {
                        Size = new Size(width, height),
                        Mode = ResizeMode.Max,
                    }));
                image.Save(outputPath); // Automatic encoder selected based on extension.
            }
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
        public Stream AddWatermark(Stream stream, Stream logoStream, Position position = Position.BottomRight, int width = 100, int height = 40, int padding = 4)
        {
            var watermarkedStream = new MemoryStream();
            using (var img = Image.Load(stream))
            {
                // 确定位置
                int px = 0;
                int py = 0;
                switch (position)
                {
                    case Position.TopLeft:
                        px = padding;
                        py = padding;
                        break;
                    case Position.TopRight:
                        py = height + padding;
                        px = img.Width - width - padding;
                        break;
                    case Position.BottomLeft:
                        px = padding;
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
                using (var logoImg = Image.Load(logoStream))
                {
                    logoImg.Mutate(img => img.Resize(new ResizeOptions
                    {
                        Size = new Size(width, height),
                        Mode = ResizeMode.Max
                    }));
                    //logoImg.SaveAsPng(logoStream);

                    img.Mutate(img => img.DrawImage(logoImg, new Point(px, py), 0.8f));
                    img.Save(watermarkedStream, new JpegEncoder() { });
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