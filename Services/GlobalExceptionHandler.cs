using Microsoft.Extensions.Logging;

namespace NotatnikSilowy.Services;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IGlobalExceptionHandler
{
    private bool isRegistered;

    public void RegisterGlobalHandlers()
    {
        if (isRegistered)
        {
            return;
        }

        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
        isRegistered = true;
    }

    public void HandleException(Exception exception, string source, bool isTerminating = false)
    {
        logger.LogCritical(
            exception,
            "Unhandled exception from {Source}. IsTerminating: {IsTerminating}",
            source,
            isTerminating);
    }

    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        var exception = e.ExceptionObject as Exception
                        ?? new Exception("Unhandled non-Exception error.");

        HandleException(exception, "AppDomain.CurrentDomain", e.IsTerminating);
    }

    private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        HandleException(e.Exception, "TaskScheduler.UnobservedTaskException", false);
        e.SetObserved();
    }
}
