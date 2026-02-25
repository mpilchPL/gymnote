using Microsoft.UI.Xaml;
using NotatnikSilowy.Services;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NotatnikSilowy.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
	private static bool handlersRegistered;

	/// <summary>
	/// Initializes the singleton application object.  This is the first line of authored code
	/// executed, and as such is the logical equivalent of main() or WinMain().
	/// </summary>
	public App()
	{
		this.InitializeComponent();
		RegisterPlatformExceptionHandlers();
	}

	private void RegisterPlatformExceptionHandlers()
	{
		if (handlersRegistered)
		{
			return;
		}

		UnhandledException += OnUnhandledException;
		handlersRegistered = true;
	}

	private static void OnUnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
	{
		GlobalExceptionBridge.Report(e.Exception, "Windows.UI.Xaml.Application.UnhandledException", true);
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

