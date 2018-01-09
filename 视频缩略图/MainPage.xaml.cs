using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


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

            files = await picker.PickMultipleFilesAsync();
            if (files != null)
            {
                isSelected = true;
           
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
                    var objThumbnail = await file.GetScaledImageAsThumbnailAsync(ThumbnailMode.VideosView,400,ThumbnailOptions.ResizeThumbnail);
                    // 创建buffer
                    var buffer = new Windows.Storage.Streams.Buffer(Convert.ToUInt32(objThumbnail.Size));
                    // 转为buffer
                    var buffer1 = await objThumbnail.ReadAsync(buffer, buffer.Capacity, InputStreamOptions.None);

                    // 获取保存文件对象
                    var saveFile = await storageFolder.CreateFileAsync(file.DisplayName + ".jpg");

                    // 将buffer写入头文件
                    await FileIO.WriteBufferAsync(saveFile, buffer1);
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
    }
}
