using System.Runtime.Versioning;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using TirsvadGUI.ArtefactsGenerator.Mvvm.ViewModels;

namespace TirsvadGUI.ArtefactsGenerator.Mvvm.Controls.ViewModels;

public partial class AppMenuBarUCViewModel : ViewModelBase
{
    public AppMenuBarUCViewModel()
    {
    }

    [TirsvadGUI.ArtefactsGenerator.Mvvm.Input.Attributes.RelayCommandAttribute]
    [SupportedOSPlatform("windows10.0.17763.0")]
    private async Task ExitApplicationAsync()
    {
        // Must run on UI thread; Application.Current.Exit() requests shutdown.
        Application.Current.Exit();

        // Keep compiler happy; exit may terminate the process immediately.
        await Task.CompletedTask;
    }
}
