using System;

using ApiToMD.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ApiToMD.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
