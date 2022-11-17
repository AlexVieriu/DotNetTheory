namespace HttpClientFactoryHowToUse.Services;

public class OperationScoped : IOperationScoped
{
    public string OperationId = Guid.NewGuid().ToString()[^4..];

    string IOperationScoped.OperationId => throw new NotImplementedException();
}
