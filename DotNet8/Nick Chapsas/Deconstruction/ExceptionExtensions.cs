namespace Deconstruction;

public static class ExceptionExtensions
{
    // the name of the method is really important 
    public static void Deconstruct(this Exception ex, out string message, out string? stackTrace)
    {
        message = ex.Message;
        stackTrace = ex.StackTrace;
    }
}
