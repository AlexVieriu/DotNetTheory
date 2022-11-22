public class WeatherForecast
{
    public int Id { get; set; }

    private readonly DateOnly _date;
    private readonly int _temperatureC;
    private readonly string? _summary;

    public WeatherForecast()
    {

    }
    public WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        _date = Date;
        _temperatureC = TemperatureC;
        _summary = Summary;
    }

    public int TemperatureF => 32 + (int)(_temperatureC / 0.5556);
}
