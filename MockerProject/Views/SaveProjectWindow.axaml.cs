using Avalonia.Controls;
using MockerProject.ViewModels;

namespace MockerProject.Views
{
    public partial class SaveProjectWindow : Window
    {
        private MainWindowViewModel m_MainVM;
        public SaveProjectWindow()
        {
            InitializeComponent();
        }
        public void setMainVM(MainWindowViewModel mainVM)
        {
            m_MainVM = mainVM;
            this.DataContext = mainVM;
        }
    }
}
