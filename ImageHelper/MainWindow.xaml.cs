using Microsoft.Win32;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        OpenFileDialog dlg;
        ImageProcess imgProcess;

        public MainWindow()
        {
            InitializeComponent();
            imgProcess = new ImageProcess();
        }

        private void Sharpness_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void SelectSourceImageBtn_Click(object sender, RoutedEventArgs e)
        {
            dlg = new OpenFileDialog
            {
                Filter = "图片格式|*.jpg;*.jpeg;*.png",
            };
            var result = dlg.ShowDialog();
            if (result == true)
            {
                // 展现到图片框中
                SourceImage.Source = new BitmapImage(new Uri(dlg.FileName));
            }

        }

        private void HandleImageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(dlg.FileName))
            {
                MessageBox.Show("请先选择源文件");
            }

            int sharpness = 90;
            if (!string.IsNullOrEmpty(SharpnessText.Text))
            {
                sharpness = Convert.ToInt32(SharpnessText.Text);
            }

            var currentDir = Environment.CurrentDirectory;
            var outputPath = System.IO.Path.Combine(currentDir, "temp.jpg");
            var fileInfo = new FileInfo(dlg.FileName);

            //using var image = SixLabors.ImageSharp.Image.Load(File.OpenRead(fileInfo.FullName));
            //image.Clone(x => x.BackgroundColor(Rgba32.Transparent));

            //image.SaveAsJpeg(outStream, new JpegEncoder
            //{
            //    Quality = sharpness
            //});
            //outStream.Seek(0, SeekOrigin.Begin);

            var helper = new ImageProcess();
            var outStream = File.OpenRead(fileInfo.FullName);
            var stream = helper.AddWatermark(outStream, File.OpenRead("./test.png"), Position.TopLeft, 200, 80);

            stream.Position = 0;
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            OutputImage.Source = bitmapImage;
            MessageBox.Show("处理完成，你可以点击保存选择将图片另存为");
        }

        private void SaveImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                DefaultExt = ".jpg",
                Filter = "JPG图片|*.jpg"
            };
            var result = sfd.ShowDialog();
            if (result == true)
            {
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)OutputImage.Source));
                using FileStream stream = new FileStream(sfd.FileName, FileMode.Create);
                encoder.Save(stream);
            }
        }
    }
}
