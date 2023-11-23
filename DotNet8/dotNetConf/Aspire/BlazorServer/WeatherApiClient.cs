namespace BlazorServer;

public class WeatherApiClient(HttpClient client)
{
    // weatherforecast is the URL for the WepAPI -> Program.cs  (app.MapGet("/weatherforecast", () => . . .)
    public async Task<WeatherForecast[]> GetWeatherForecasts() =>
       await client.GetFromJsonAsync<WeatherForecast[]>("weatherforecast") ?? [];
}

