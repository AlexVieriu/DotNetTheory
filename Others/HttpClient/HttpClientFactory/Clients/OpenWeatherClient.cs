using Newtonsoft.Json;

namespace NickChapsas_HttpClientFactory.Clients;

public class OpenWeatherClient : IWeatherClient
{
    public const string ClientName = "weatherApi";
    private const string OpenWeatherMapApiKey = "caf1cd4d166f4f191f881349a3223cbb";
    private readonly IHttpClientFactory _clientFactory;

    public OpenWeatherClient(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<WeatherResponse?> GetCurrentWeatherForCast(string city)
    {
        try
        {
            var client = _clientFactory.CreateClient(ClientName);           

            var response = await client.GetFromJsonAsync<WeatherResponse?>
                ($"weather?q={city}&appid={OpenWeatherMapApiKey}");

            return response;           
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
