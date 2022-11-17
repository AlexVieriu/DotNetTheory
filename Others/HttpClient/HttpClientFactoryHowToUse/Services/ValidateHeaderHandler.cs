namespace HttpClientFactoryHowToUse.Services;

public class ValidateHeaderHandler : DelegatingHandler
{
    private const string ApiKey = "X-API-KEY";
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                 CancellationToken cancellationToken)
    {
        if(!request.Headers.Contains(ApiKey))
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent($"The API key {ApiKey} is requered")
            };
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
