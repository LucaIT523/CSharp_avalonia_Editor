
using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Input;

namespace MockerProject.Views
{
    public partial class ScreenSmallView : UserControl
    {
        public List<Control> g_Controls = new List<Control>();
        
        public ScreenSmallView()
        {
            InitializeComponent();
            
            
        }

        public void sendCommand(int x)
        {
            Button w_Control = null;
            w_Control = new Button();
            g_Controls.Add(w_Control);
            w_Control.Width = 100;
            w_Control.Height = 50;
            w_Control.Content = "New Button";
            Canvas.SetLeft(w_Control, 10);
            Canvas.SetTop(w_Control, 10);
            this.SmallCanvas.Children.Add(w_Control);
        }
    }
}
