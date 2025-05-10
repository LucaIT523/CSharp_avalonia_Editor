using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MockerProject.ViewModels;
using MockerProject.Views;
using ReactiveUI;

namespace MockerProject
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
                MainWindowViewModel mainViewModel = (MainWindowViewModel)desktop.MainWindow.DataContext;
                mainViewModel.setMainWindow(desktop.MainWindow);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}