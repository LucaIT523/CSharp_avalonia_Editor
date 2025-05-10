using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using MockerProject.ViewModels;

namespace MockerProject.Views
{
    public partial class PlatformView : UserControl
    {
        private MainWindowViewModel m_MainViewModel;
        public PlatformView()
        {
            InitializeComponent(); 

            colorButton.PropertyChanged += (s, e) =>
            {
                if (e.Property == AvaloniaColorPicker.ColorButton.ColorProperty)
                {
                    m_MainViewModel = (MainWindowViewModel)this.DataContext;
                    m_MainViewModel.m_PlatformView = this;
                    //Do something
                    Color w_Color = colorButton.Color;
                    if(w_Color.A != 255)
                        m_MainViewModel.PG_OPT = (double)w_Color.A / 255.0;
                    //colorButton.Color = new Color(255, w_Color.R, w_Color.G, w_Color.B);
                    SolidColorBrush w_IBrush = new SolidColorBrush(new Color(255, w_Color.R, w_Color.G, w_Color.B));
                    m_MainViewModel.PageBackground = w_IBrush;
                }
            };
        }
    }
}
