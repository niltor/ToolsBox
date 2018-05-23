using System;
using System.Windows.Input;
using ApiToMD.Helpers;
using ApiToMD.Models;
using Windows.UI.Popups;

namespace ApiToMD.ViewModels
{
    public class MainViewModel : Observable
    {
        /// <summary>
        /// json内容
        /// </summary>
        private string _jsonContent;
        public string JsonContent
        {
            get { return _jsonContent; }

            set { Set(ref _jsonContent, value); }
        }

        private string _jsonPath;
        /// <summary>
        /// json 链接地址
        /// </summary>
        public string JsonPath
        {
            get { return _jsonPath; }

            set { Set(ref _jsonPath, value); }
        }

        private string _outputPath;
        /// <summary>
        /// 输出路径
        /// </summary>
        public string OutputPath
        {
            get { return _outputPath; }
            set { Set(ref _outputPath, value); }
        }

        private string _outputContent;
        /// <summary>
        /// 输出内容
        /// </summary>
        public string OutputContent
        {
            get { return _outputContent; }
            set { Set(ref _outputContent, value); }
        }
        /// <summary>
        /// postman输出选项
        /// </summary>
        public PostmanOption PostmanOption { get; set; }

        public MainViewModel()
        {
        }
        public void Initialize()
        {

        }

        /// <summary>
        /// 选择按钮
        /// </summary>
        public async void OnChoseClickAsync()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.ComputerFolder
            };
            picker.FileTypeFilter.Add(".json");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.JsonPath = file.Path ;
            }
           
        }

    }
}
