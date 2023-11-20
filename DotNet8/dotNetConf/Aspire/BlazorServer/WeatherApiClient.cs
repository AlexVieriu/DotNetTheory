namespace BlazorServer;

public class WeatherApiClient(HttpClient client)
{
    public async Task<WeatherForecast[]> GetWeatherForecasts() =>
       await client.GetFromJsonAsync<WeatherForecast[]>("weatherforecast") ?? [];
}

