using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using ApiToMD.Helpers;
using ApiToMD.Models;
using ApiToMD.Services;
using Windows.Storage;
using Windows.Storage.Pickers;
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
        public StorageFile OutputFile { get; set; }


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
            var picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.ComputerFolder
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
                dialog.ShowAsync();
                return;
            }
            var content = await FileIO.ReadTextAsync(JsonFile);

            JsonContent = content.Replace("\t", "  ");
        }

        /// <summary>
        /// 生成按钮事件
        /// </summary>
        public async void OnGenerateClickAsync()
        {

            var service = new PostmanService();
            if (JsonFile == null)
            {
                dialog.Content = "请先选择文件来源";
                var re = dialog.ShowAsync();
            }
            else
            {
                var content = await service.ToMarkdownAsync(JsonFile);
                OutputContent = content;
            }
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        public async void OnSaveContentClickAsync()
        {
            if (JsonContent == null)
            {
                dialog.Content = "请先加载json文件";
                dialog.ShowAsync();
                return;
            }

            var savePicker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                SuggestedFileName = JsonFile.DisplayName,
                DefaultFileExtension = ".md"
            };
            savePicker.FileTypeChoices.Add("markdown file", new List<string>() { ".md", ".markdown" });

            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                await FileIO.WriteTextAsync(file, OutputContent);
            }
        }
    }
}
