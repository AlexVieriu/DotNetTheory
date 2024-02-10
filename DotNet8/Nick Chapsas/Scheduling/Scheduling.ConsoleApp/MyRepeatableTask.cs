namespace Scheduling.ConsoleApp;

public class MyRepeatableTask : IInvocable
{
    private readonly ILogger<MyRepeatableTask> _logger;
    private readonly string _conString;

    public MyRepeatableTask(ILogger<MyRepeatableTask> logger, string conString)
    {
        _logger = logger;
        _conString = conString;
    }

    public async Task Invoke()
    {
        _logger.LogInformation("Hello from invocable, with connection string: {_conString}", _conString);
    }
}
