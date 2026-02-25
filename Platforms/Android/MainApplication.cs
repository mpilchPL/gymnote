using Android.App;
using Android.Runtime;
using NotatnikSilowy.Services;

namespace NotatnikSilowy;

[Application]
public class MainApplication : MauiApplication
{
	private static bool handlersRegistered;

	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
		RegisterPlatformExceptionHandlers();
	}

	private static void RegisterPlatformExceptionHandlers()
	{
		if (handlersRegistered)
		{
			return;
		}

		AndroidEnvironment.UnhandledExceptionRaiser += OnUnhandledException;
		handlersRegistered = true;
	}

	private static void OnUnhandledException(object? sender, RaiseThrowableEventArgs e)
	{
		GlobalExceptionBridge.Report(e.Exception, "AndroidEnvironment.UnhandledExceptionRaiser", true);
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
