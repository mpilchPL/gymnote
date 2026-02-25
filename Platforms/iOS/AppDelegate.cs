using Foundation;
using NotatnikSilowy.Services;
using ObjCRuntime;

namespace NotatnikSilowy;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	private static bool handlersRegistered;

	public override bool FinishedLaunching(UIKit.UIApplication application, NSDictionary launchOptions)
	{
		RegisterPlatformExceptionHandlers();
		return base.FinishedLaunching(application, launchOptions);
	}

	private static void RegisterPlatformExceptionHandlers()
	{
		if (handlersRegistered)
		{
			return;
		}

		Runtime.MarshalManagedException += OnMarshalManagedException;
		handlersRegistered = true;
	}

	private static void OnMarshalManagedException(object? sender, MarshalManagedExceptionEventArgs e)
	{
		GlobalExceptionBridge.Report(e.Exception, "ObjCRuntime.Runtime.MarshalManagedException", true);
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
