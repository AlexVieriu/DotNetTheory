﻿using Newtonsoft.Json;

namespace NickChapsas_HttpClientFactory.Clients;

public class OpenWeatherClient : IWeatherClient
{
    public const string ClientName = "weatherApi";
    private const string OpenWeatherMapApiKey = "caf1cd4d166f4f191f881349a3223cbb";
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/")
    };
    
    public async Task<WeatherResponse?> GetCurrentWeatherForCast(string city)
    {
        return await _httpClient.GetFromJsonAsync<WeatherResponse?>(
            $"weather?q={city}&appid={OpenWeatherMapApiKey}");
    }
}
