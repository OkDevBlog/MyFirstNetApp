using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;

[assembly: SupportedOSPlatform("browser")]

internal sealed partial class Program
{
    private static Task Main(string[] args) => BuildAvaloniaApp()
        .StartBrowserAppAsync("out", new BrowserPlatformOptions
        {
            RenderingMode = new[]
            {
                BrowserRenderingMode.Software2D,
                BrowserRenderingMode.WebGL1,
                BrowserRenderingMode.WebGL2
            }
        });

    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<MyCrossApp.App>();
    }
}