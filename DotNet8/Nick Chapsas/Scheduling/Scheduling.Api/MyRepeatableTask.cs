using Coravel.Invocable;

namespace Scheduling.Api;

public class MyRepeatableTask : IInvocable
{
    private readonly ILogger<MyRepeatableTask> _logger;
    public MyRepeatableTask(ILogger<MyRepeatableTask> logger)
    {
        _logger = logger;
    }

    public async Task Invoke()
    {
        _logger.LogInformation("Hello from invocable");
    }
}