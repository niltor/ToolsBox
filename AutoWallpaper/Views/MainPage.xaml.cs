using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System.UserProfile;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace AutoWallpaper.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private async void Test_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            bool success = false;
            if (UserProfilePersonalizationSettings.IsSupported())
            {
                var imageFile = await StorageFile.GetFileFromPathAsync(@"C:\Users\NilTor\Pictures\123.jpg");
                await imageFile.CopyAsync(ApplicationData.Current.LocalFolder, "test.jpg", NameCollisionOption.ReplaceExisting);
                StorageFile file = await StorageFile.GetFileFromPathAsync(Path.Combine(ApplicationData.Current.LocalFolder.Path, "test.jpg"));
                UserProfilePersonalizationSettings profileSettings = UserProfilePersonalizationSettings.Current;
                success = await profileSettings.TrySetWallpaperImageAsync(file);
            }
            var dialog = new MessageDialog("失败");
            if (success)
            {
                dialog.Content = "成功";
            }
            await dialog.ShowAsync();
        }
    }
}
