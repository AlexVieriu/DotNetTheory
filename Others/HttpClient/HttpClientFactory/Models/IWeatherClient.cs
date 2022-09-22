namespace HttpClientFactory.Models;

public interface IWeatherClient
{
    Task<WeatherResponse?> GetCurrentWeatherForCast(string city);
}
