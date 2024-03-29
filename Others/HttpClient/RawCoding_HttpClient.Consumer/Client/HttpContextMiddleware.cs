﻿namespace RawCoding_HttpClient.Consumer.Client;

public class HttpContextMiddleware : DelegatingHandler
{
    private string _ctor;

    public HttpContextMiddleware()
    {
        _ctor = Guid.NewGuid().ToString();
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                           CancellationToken cancellationToken)
    {
        try
        {
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
