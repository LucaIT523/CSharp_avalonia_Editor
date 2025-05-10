using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using MockerProject.ViewModels;

namespace MockerProject.Views;

public partial class ProjectTaskbarView : UserControl
{
    public ProjectTaskbarView()
    {
        InitializeComponent();
        //this.PointerReleased += onSetRefresh();
        /*((MainWindowViewModel)this.DataContext).w_nLeftPosition = 1;*/
        Project.AddHandler(ToggleButton.PointerReleasedEvent, (sender, e) =>
        {
            ((MainWindowViewModel)this.DataContext).IsProjectView = true;
        }, handledEventsToo: true);
    }

    public void onSetRefresh(object sender, RoutedEventArgs e)
    {
        //int x = this.myList.ItemCount;
        //this.myList.GetType();

    }
}