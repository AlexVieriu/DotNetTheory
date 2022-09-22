using System.Net;

namespace ImplementRetriesInDotNet.Clients;

public class OpenWeatherClient3 : IWeatherClient
{
    public const string ClientName = "weatherapi";
    private const string OpenWeatherApiMapKey = "caf1cd4d166f4f191f881349a3223cbb";
    private readonly IHttpClientFactory _clientFactory;

    public OpenWeatherClient3(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<WeatherResponse?> GetCurrentWeatherForCity(string city)
    {
        var client = _clientFactory.CreateClient(ClientName);
        var retryCount = 0;

    Start:
        try
        {
            var response = await client.GetAsync($"weather?q={city}&appid={OpenWeatherApiMapKey}");

            if (response.StatusCode >= HttpStatusCode.InternalServerError || response.StatusCode == HttpStatusCode.RequestTimeout)
                if (retryCount > 5)
                {
                    // return 
                }
                else
                {
                    await Task.Delay(1000);
                    retryCount++;
                    goto Start;
                    // retry 
                }

            return await response.Content.ReadFromJsonAsync<WeatherResponse>();
        }
        catch (HttpRequestException ex)
        {
            await Task.Delay(1000);
            retryCount++;
            goto Start;
            // retry
        }
    }
}
