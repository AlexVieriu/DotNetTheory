namespace HttpClientFactoryHowToUse.Services;

public class OperationHandler : DelegatingHandler
{
    private readonly IOperationScoped _operationScoped;

    public OperationHandler(IOperationScoped operationScoped)
    {
        _operationScoped = operationScoped;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                           CancellationToken cancellationToken)
    {
        request.Headers.Add("X-OPERATION-ID", _operationScoped.OperationId);

        return base.SendAsync(request, cancellationToken);
    }
}
