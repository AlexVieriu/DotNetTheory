using System.Net;

namespace ImplementRetriesInDotNet.Clients;

public class OpenWeatherClient2 : IWeatherClient
{
    public const string ClientName = "weatherapi";
    private const string OpenWeatherApiMapKey = "caf1cd4d166f4f191f881349a3223cbb";
    private readonly IHttpClientFactory _clientFactory;

    // we can define it in one place and reuse it everywhere
    private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy =
        Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .OrResult(x => x.StatusCode >= HttpStatusCode.InternalServerError || 
                           x.StatusCode == HttpStatusCode.RequestTimeout)
            .RetryAsync(5); // the retries will be back to back, will not be any wait between them 

    public OpenWeatherClient2(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<WeatherResponse?> GetCurrentWeatherForCity(string city)
    {
        var client = _clientFactory.CreateClient(ClientName);

        var response = await _retryPolicy.ExecuteAsync(() => 
            client.GetAsync($"weather?q={city}&appid={OpenWeatherApiMapKey}"));

        return await response.Content.ReadFromJsonAsync<WeatherResponse>();
    }
}
