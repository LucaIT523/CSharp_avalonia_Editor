using Avalonia.Controls;
using Avalonia.Input;
using MockerProject.ViewModels;

namespace MockerProject.Views
{
    public partial class UIControlView : UserControl
    {
        public UIControlView()
        {
            InitializeComponent();
            //this.PointerPressed += onMouseUp;
            //this.Button.PointerMoved += onMouseMove;
        }

        

        /*private void onMouseMove(object sender, PointerEventArgs e)
        {
            MainWindowViewModel mainViewModel = (MainWindowViewModel)this.DataContext;
            int w_UIControlType = mainViewModel.m_UIControlType;
            if (w_UIControlType > 0)
            {
                
            }
        }*/
    }
}
