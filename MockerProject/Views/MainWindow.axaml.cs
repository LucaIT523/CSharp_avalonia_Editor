using System.ComponentModel;
using Avalonia.Controls;
using MockerProject.ViewModels;

namespace MockerProject.Views
{
    public partial class MainWindow : Window
    {
        //public ContentControl m_ShareWindowContainer;
        private MenuBoxView g_MenuBox;
        private StartMockerView NewProjectView;
        public MainWindow()
        {
            InitializeComponent();
            //m_ShareWindowContainer = ShareWindowContainer;
            this.Closing += MainWindow_Closing;
            NewProjectView = new StartMockerView();
            StartMockerControl.Content = NewProjectView;
            StartMockerControl.Width = 550;
            
            g_MenuBox = new MenuBoxView();
            MenuContentControl.Content = g_MenuBox;
            MenuContentControl.Width = 250;
            
            this.PointerPressed += (sender, e) =>
            {
                MainWindowViewModel m_MainViewModel = (MainWindowViewModel)this.DataContext;
                if(m_MainViewModel.m_wndUIProperty !=null && !m_MainViewModel.m_wndUIProperty.ppopup.IsPointerOver)
                {
                    m_MainViewModel.m_wndUIProperty.ppopup.IsOpen = false;
                }

                if (MenuContentControl.IsPointerOver == false)
                    m_MainViewModel.IsMenuOpened = false;
            };
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindowViewModel m_MainViewModel = (MainWindowViewModel)this.DataContext;
            if (m_MainViewModel.m_wndUIProperty != null)
            {
                m_MainViewModel.m_wndUIProperty.Close();
            }
        }

    }
}