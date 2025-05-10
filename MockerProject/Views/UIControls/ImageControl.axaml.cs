using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using MockerProject.ViewModels;
using MockerProject.Services;
using ReactiveUI;

namespace MockerProject.Views
{
    public partial class ImageControl : UIControl
    {
        public ImageControl()
        {
            InitializeComponent();
            this.DataContext = m_ControlViewModel;
            m_ControlViewModel.IsFitVisible = false;
            m_ControlViewModel.IsBorderVisible = false;
            m_ControlViewModel.m_IsBorderColorVisible = false;
            m_ControlViewModel.IsTextPropertiesVisible = false;
            m_strSrc = "Assets\\Mocker.png";
            image.AddHandler(TextBox.DoubleTappedEvent, async (sender, e) =>
            {
                m_MainViewModel.m_wndUIProperty.Hide();
                m_IsDoubleTapped = true;
                setImage(null);
            }, handledEventsToo: true);
        }

        public async void setImage([AllowNull] string src)
        {
            if (src==null)
            {
                var storageProvider = StorageService.GetStorageProvider();
                var result = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
                {
                    Title = "Open Project",
                    FileTypeFilter = GetCodeFileTypes(),
                    AllowMultiple = false
                });
                var file = result.FirstOrDefault();
                if(file==null)return;
                src = file.Path.AbsolutePath;
                m_strSrc =src;
            }
            if(!File.Exists(src)) return;
            var bitmap = new Bitmap(src);
            image.Source = bitmap;
        }
        private static List<FilePickerFileType> GetCodeFileTypes()
        {
            return new List<FilePickerFileType>
            {
                StorageService.IMG,
                StorageService.All
            };
        }
        /*private void onMousePressed(object sender, PointerPressedEventArgs e)
        {
            var properties = e.GetCurrentPoint(this).Properties;
            if (properties.IsLeftButtonPressed)
            {
                sX = e.GetPosition(this).X;
                sY = e.GetPosition(this).Y;
                m_MainViewModel.m_nSelectedUIControl = m_nIndex;
            }
            else
            {
                m_MainViewModel.m_nSelectedUIControl = 0;
            }
        }
        private void onMouseReleased(object sender, PointerReleasedEventArgs e)
        {
            m_MainViewModel.m_nSelectedUIControl = 0;
            if (m_IsDoubleTapped)
            {
                m_IsDoubleTapped = false;
                return;
            }
            if (m_MainViewModel.m_wndUIProperty==null || !m_MainViewModel.m_wndUIProperty.IsVisible)
                m_MainViewModel.m_wndUIProperty = new UIPropertyWindow();
            else
            {
                m_MainViewModel.m_wndUIProperty.Close();
                m_MainViewModel.m_wndUIProperty = new UIPropertyWindow();
            }
            Point cP = e.GetPosition(this);
            Point mP = e.GetPosition(m_MainViewModel.m_MainWindow);
            PixelPoint cPP = new PixelPoint((int)(mP.X-cP.X+m_nWidth), (int)(mP.Y-cP.Y));
            PixelPoint nPP = m_MainViewModel.m_MainWindow.Position;
            m_MainViewModel.m_wndUIProperty.Position = nPP+cPP;
            ((UIPropertyWindow)m_MainViewModel.m_wndUIProperty).setMainViewModel(m_MainViewModel);
            ((UIPropertyWindow)m_MainViewModel.m_wndUIProperty).setControlInfo(m_ControlViewModel, this);
            m_MainViewModel.m_wndUIProperty.Show();
        }*/
    }
}
