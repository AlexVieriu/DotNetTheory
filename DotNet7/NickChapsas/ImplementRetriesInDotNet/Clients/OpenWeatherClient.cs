namespace ImplementRetriesInDotNet.Clients;

public class OpenWeatherClient : IWeatherClient
{
    public const string ClientName = "weatherapi";
    private const string OpenWeatherApiMapKey = "caf1cd4d166f4f191f881349a3223cbb";
    private readonly IHttpClientFactory _clientFactory;

    public OpenWeatherClient(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<WeatherResponse?> GetCurrentWeatherForCity(string city)
    {
        var client = _clientFactory.CreateClient(ClientName);

        var response = await client.GetAsync($"weather?q={city}&appid={OpenWeatherApiMapKey}");

        return await response.Content.ReadFromJsonAsync<WeatherResponse>();
    }
}
