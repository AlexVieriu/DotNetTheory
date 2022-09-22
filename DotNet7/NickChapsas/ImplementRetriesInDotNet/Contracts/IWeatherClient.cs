namespace ImplementRetriesInDotNet.Contracts;

public interface IWeatherClient
{
    Task<WeatherResponse?> GetCurrentWeatherForCity(string city);
}
