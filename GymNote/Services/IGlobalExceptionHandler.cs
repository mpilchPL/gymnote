namespace GymNote.Services;

public interface IGlobalExceptionHandler
{
    void RegisterGlobalHandlers();
    void HandleException(Exception exception, string source, bool isTerminating = false);
}
