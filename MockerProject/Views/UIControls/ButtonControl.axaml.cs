using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using MockerProject.ViewModels;

namespace MockerProject.Views
{
    public partial class ButtonControl : UIControl
    {
        /*private MainWindowViewModel m_MainViewModel;
        public int m_nIndex = 0;
        
        private Point m_currentControlPoint;
        private Size m_currentControlSize;*/

        public ButtonControl()
        {
            InitializeComponent();
            this.DataContext = m_ControlViewModel;
            setBackground(new SolidColorBrush(new Color(255, 200, 200, 200)));
            setForeground(new SolidColorBrush(new Color(255, 33, 33, 33)));
            setBorderColor(new SolidColorBrush(new Color(255, 77, 77, 77)));
            setBorderThickness(1);
            setBorderRound(5);
            //m_MainViewModel = (MainWindowViewModel)this.DataContext;
            
            //m_MainViewModel.m_wndUIProperty = new SetResponseWindow();
            /*button.AddHandler(Button.PointerPressedEvent, (sender, e) =>
            {
                sX = e.GetPosition(this).X;
                sY = e.GetPosition(this).Y;
                if(m_MainViewModel!=null)
                    m_MainViewModel.m_nSelectedUIControl = m_nIndex;
            }, handledEventsToo: true);
            button.AddHandler(Button.DoubleTappedEvent, (sender, e) =>
            {
                //if(m_MainViewModel!=null)
                //    m_MainViewModel.m_nSelectedUIControl = m_nIndex;
            }, handledEventsToo: true);
            button.AddHandler(Button.PointerReleasedEvent, (sender, e) =>
            {
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
            }, handledEventsToo: true);*/
        }
    }
}
