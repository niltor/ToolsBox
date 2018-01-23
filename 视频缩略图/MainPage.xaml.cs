using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace 视频缩略图
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool isSelected = false;
        private MessageDialog dialog;
        private IReadOnlyList<StorageFile> files = new List<StorageFile>();
        public MainPage()
        {
            this.InitializeComponent();
            // 
            ApplicationView.PreferredLaunchViewSize = new Size(400, 200);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // 打开窗口选择文件
            var picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.ComputerFolder
            };
            picker.FileTypeFilter.Add(".mp4");
            picker.FileTypeFilter.Add(".mkv");
            picker.FileTypeFilter.Add(".avi");
            picker.FileTypeFilter.Add(".wmv");

            Message.Text = "正在选择视频";
            files = await picker.PickMultipleFilesAsync();
            if (files != null)
            {
                isSelected = true;
                Message.Text = "已选择视频";
            }
        }

        private async void SaveThumbnail_Click(object sender, RoutedEventArgs e)
        {
            if (isSelected)
            {
                var folderPicker = new FolderPicker
                {
                    SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                    ViewMode = PickerViewMode.Thumbnail
                };
                folderPicker.FileTypeFilter.Add("*");
                // 获取存储路径
                var storageFolder = await folderPicker.PickSingleFolderAsync();

                foreach (var file in files)
                {
                    // 获取视频截图
                    var objThumbnail = await file.GetThumbnailAsync(ThumbnailMode.VideosView, 800, ThumbnailOptions.ResizeThumbnail);
                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(objThumbnail.CloneStream());
                    var outputBitmap = await decoder.GetSoftwareBitmapAsync();
                    // 获取保存文件对象
                    var saveFile = await storageFolder.CreateFileAsync(file.DisplayName + ".jpg", CreationCollisionOption.GenerateUniqueName);

                    // 写入文件
                    SaveSoftwareBitmapToFile(outputBitmap, saveFile);
                }
                dialog = new MessageDialog("处理完成");
                dialog.Commands.Add(new UICommand("确定", cmd => { }, commandId: 0));
                dialog.DefaultCommandIndex = 0;
                //获取返回值
                var result = await dialog.ShowAsync();
            }
            else
            {
                dialog = new MessageDialog("没有选择任何视频");
                dialog.Commands.Add(new UICommand("确定", cmd => { }, commandId: 0));
                //设置默认按钮，不设置的话默认的确认按钮是第一个按钮
                dialog.DefaultCommandIndex = 0;
                //获取返回值
                var result = await dialog.ShowAsync();
            }
        }

        /// <summary>
        /// 保存softwarebitmap到文件
        /// </summary>
        /// <param name="softwareBitmap"></param>
        /// <param name="outputFile"></param>
        private async void SaveSoftwareBitmapToFile(SoftwareBitmap softwareBitmap, StorageFile outputFile)
        {
            using (IRandomAccessStream stream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                // 设置Encoder属性,jpeg 质量
                var propertySet = new BitmapPropertySet();
                var qualityValue = new BitmapTypedValue(0.8, PropertyType.Single);
                propertySet.Add("ImageQuality", qualityValue);

                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream, propertySet);
                encoder.SetSoftwareBitmap(softwareBitmap);

                // 设置输出文件属性
                encoder.BitmapTransform.ScaledWidth = 400;
                encoder.BitmapTransform.ScaledHeight = 300;
                // encoder.BitmapTransform.Rotation = Windows.Graphics.Imaging.BitmapRotation.Clockwise90Degrees;
                // 设置插值方式
                encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Linear;
                encoder.IsThumbnailGenerated = true;

                try
                {
                    await encoder.FlushAsync();
                }
                catch (Exception err)
                {
                    switch (err.HResult)
                    {
                        case unchecked((int)0x88982F81): 
                            encoder.IsThumbnailGenerated = false;
                            break;
                        default:
                            throw err;
                    }
                }
                if (encoder.IsThumbnailGenerated == false)
                {
                    await encoder.FlushAsync();
                }
            }
        }
    }
}
