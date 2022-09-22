namespace NickChapsas_HttpClientFactory.Models;

public class WeatherResponse
{
    public Main main { get; set; }
}

public class Main
{
    public float temp { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
    public int temp_min { get; set; }
    public int temp_max { get; set; }
}
