using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using MockerProject.ViewModels;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace MockerProject.Views
{
    public partial class LabelControl : UIControl
    {
        //private UIControlViewModel m_ControlViewModel;
        public bool m_IsDoubleTapped = false;

        public LabelControl()
        {
            InitializeComponent();
            this.DataContext = m_ControlViewModel;
            setFitWidth(true);
            setFitHeight(true);
            setBackground(new SolidColorBrush(new Color(0, 255, 255, 255)));
            setForeground(new SolidColorBrush(new Color(255, 33, 33, 33)));
            setBorderColor(new SolidColorBrush(new Color(0, 255, 255, 255)));
            label.AddHandler(TextBox.DoubleTappedEvent, (sender, e) =>
            {
                m_MainViewModel.m_wndUIProperty.Hide();
                m_IsDoubleTapped = true;
            }, handledEventsToo: true);
        }
        public void setMainViewModel(MainWindowViewModel mainViewModel)
        {
            m_MainViewModel = mainViewModel;
            m_nIndex = m_MainViewModel.WorkScreen.screenCanvas.Children.Count;
        }
        public void setFitWidth()
        {
            label.TextWrapping = TextWrapping.Wrap;
            label.Width = double.NaN;
            label.Measure(Size.Infinity);
            label.Width = label.DesiredSize.Width;
            setWidth(label.Width);
        }
        public void setFitHeight()
        {
            label.TextWrapping = TextWrapping.Wrap;
            label.Height = double.NaN;
            label.Measure(Size.Infinity);
            label.Height = label.DesiredSize.Height;
            
            setHeight(label.Height);
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
            if (m_IsDoubleTapped)
            {
                m_IsDoubleTapped = false;
                return;
            }
            m_MainViewModel.m_nSelectedUIControl = 0;
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
