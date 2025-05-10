using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using MockerProject.ViewModels;

namespace MockerProject.Views
{
    public partial class RadioControl : UIControl
    {
        public RadioControl()
        {
            InitializeComponent();
            this.DataContext = m_ControlViewModel;
            setSize(100, 30);
            setName("Radio");
            setFontSize(14);
            setText("Radio");
            //setForeground(new SolidColorBrush(new Color(255, 33, 33, 33)));
            //setFontSizeID(7);
        }
    }
}
