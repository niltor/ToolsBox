using System;
using System.IO;
using System.Windows.Input;
using ApiToMD.Helpers;
using ApiToMD.Models;
using Windows.Storage;
using Windows.UI.Popups;

namespace ApiToMD.ViewModels
{
    public class MainViewModel : Observable
    {

        protected MessageDialog dialog;

        /// <summary>
        /// json内容
        /// </summary>
        private string _jsonContent;
        public string JsonContent
        {
            get { return _jsonContent; }

            set { Set(ref _jsonContent, value); }
        }
        public StorageFile JsonFile { get; set; }

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
            dialog = new MessageDialog("");
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

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                JsonFile = file;
                JsonPath = file.Path;
            }

        }
        /// <summary>
        /// load Json内容
        /// </summary>
        public async void OnLoadContentClickAsync()
        {
            if (JsonPath == null)
            {
                dialog.Content = "请先选择文件或输入url";
                return;
            }
            var content = await FileIO.ReadTextAsync(JsonFile);
            JsonContent = content;
        }


        public void OnGenerateClickAsync()
        {

        }

        public void OnSaveContentClickAsync()
        { }
    }
}
