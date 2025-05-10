using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MockerProject.Views
{
    public partial class UploadResponse : Window
    {
        public UploadResponse()
        {
            InitializeComponent();
            shareLink.AddHandler(Border.TappedEvent, (sender, e) =>
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("C:/Program Files/Google/Chrome/Application/chrome.exe",shareLink.Text);
                Process.Start(sInfo);
            }, handledEventsToo: true);
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_OnCopy(object? sender, RoutedEventArgs e)
        {
            Clipboard.SetTextAsync(shareLink.Text);
        }
    }
}
