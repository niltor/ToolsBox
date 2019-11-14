using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Primitives;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System.IO;

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
                        Size = new Size(width, height),
                        Mode = ResizeMode.Max,
                    }));
                image.Save(outputPath); // Automatic encoder selected based on extension.
            }
        }
    }
}
