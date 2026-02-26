using System.Diagnostics;

namespace GymNote.Services;

public static class GlobalExceptionBridge
{
    private static IGlobalExceptionHandler? handler;

    public static void Initialize(IGlobalExceptionHandler globalExceptionHandler)
    {
        handler = globalExceptionHandler;
    }

    public static void Report(Exception exception, string source, bool isTerminating = false)
    {
        if (handler is null)
        {
            Debug.WriteLine($"Unhandled exception from {source}: {exception}");
            return;
        }

        handler.HandleException(exception, source, isTerminating);
    }
}
