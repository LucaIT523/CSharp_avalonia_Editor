using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Remote.Protocol.Input;
using MockerProject.ViewModels;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace MockerProject.Views
{
    public struct stControlHistory
    {
        public int Index;
        public string Cmd;
        
        public int id;
        public Type type;
        public Control oldInfo;
        public Control curInfo;
    }
    public partial class ScreenView : UserControl
    {
        private MainWindowViewModel m_MainViewModel;
        public List<stControlHistory> m_UndoList = new List<stControlHistory>();
        public List<stControlHistory> m_RedoList = new List<stControlHistory>();
        public string m_strName = "Page1";
        public bool m_Orientation = true;
        public Size m_Size = new Size(375, 647);
        public SolidColorBrush m_background = new SolidColorBrush(new Color(255, 255, 255, 255));
        public double m_Opacity = 0.33;
        public ScreenView()
        {
            InitializeComponent();
            //this.PointerMoved += onMouseMove;
        }
        private void onMousePressed(object sender, PointerPressedEventArgs e)
        {
            m_MainViewModel = (MainWindowViewModel)this.DataContext;
            var properties = e.GetCurrentPoint(this).Properties;
            if (properties.IsLeftButtonPressed)
            {
                m_MainViewModel.m_UIControlType = 1;
            }
            else
            {
                m_MainViewModel.m_UIControlType = 0;
            }
        }
        private void onMouseReleased(object sender, PointerReleasedEventArgs e)
        {
            m_MainViewModel.m_UIControlType = 0;
        }
    }
}
