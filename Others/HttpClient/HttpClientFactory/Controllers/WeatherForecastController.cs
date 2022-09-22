namespace HttpClientFactory.Controllers;

[ApiController]

public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherClient _weatherClient;

    public WeatherForecastController(IWeatherClient weatherClient)
    {
        _weatherClient = weatherClient;
    }

    [HttpGet("weather/{city}")]
    public async Task<IActionResult> Forecast(string city)
    {
        var weather = await _weatherClient.GetCurrentWeatherForCast(city);

        return weather is null ? NotFound() : Ok(weather);
    }
}
