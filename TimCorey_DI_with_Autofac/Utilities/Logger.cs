namespace TimCorey_DI_with_Autofac.Utilities;

public class Logger : ILogger
{
    public void Log(string message)
        => Console.WriteLine(message);
}

