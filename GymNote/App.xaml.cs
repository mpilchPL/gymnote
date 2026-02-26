using GymNote.Services;

namespace GymNote;

public partial class App : Application
{
	public App(IGlobalExceptionHandler globalExceptionHandler)
	{
		InitializeComponent();
		globalExceptionHandler.RegisterGlobalHandlers();
		GlobalExceptionBridge.Initialize(globalExceptionHandler);
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}