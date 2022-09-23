namespace RawCoding_HttpClient.Consumer.Client;

public class HttpContextMiddleware : DelegatingHandler
{
    private readonly IHttpContextAccessor _accessor;
    private HttpContext httpContext;
    private string _ctor;

    public HttpContextMiddleware(IHttpContextAccessor accessor)
    {
        _ctor = Guid.NewGuid().ToString();
        _accessor = accessor;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            httpContext = _accessor.HttpContext;
            if (httpContext.User == null)
            {

            }

            var method = Guid.NewGuid().ToString();

            request.Headers.Add("Middleware-Ctor", _ctor);
            request.Headers.Add("Middleware-Method", method);

            return base.SendAsync(request, cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
