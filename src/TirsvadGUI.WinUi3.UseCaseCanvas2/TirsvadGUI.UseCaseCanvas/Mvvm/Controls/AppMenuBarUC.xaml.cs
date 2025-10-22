using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TirsvadGUI.ArtefactsGenerator.Mvvm.Controls;

public sealed partial class AppMenuBarUC : UserControl
{
    public AppMenuBarUC()
    {
        InitializeComponent();
        // assign viewmodel instance so the DataContext is available for bindings
        this.DataContext = new ViewModels.AppMenuBarUCViewModel();
    }
}
