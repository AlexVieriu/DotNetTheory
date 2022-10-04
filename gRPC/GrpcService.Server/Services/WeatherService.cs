namespace GrpcService.Server.Services;

public class WeatherService : WeatherServiceBase
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<WeatherService> _logger;
    private const string ApiKey = "caf1cd4d166f4f191f881349a3223cbb";

    public WeatherService(IHttpClientFactory clientFactory, ILogger<WeatherService> logger)
    {
        _clientFactory = clientFactory;
        _logger = logger;
    }

    public override async Task<WeatherResponse> GetCurrentWeather(GetCurrentWeatherForCityRequest request,
                                                                  ServerCallContext context)
    {
        try
        {
            var httpClient = _clientFactory.CreateClient();
            var temperatures = await GetCurrentTemperaturesAsync(request, httpClient);

            return new WeatherResponse
            {
                Temperature = temperatures!.Main.Temp,
                FeelsLike = temperatures.Main.FeelsLike,
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),
                City = request.City,
                Units = request.Units
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public override async Task GetCurrentWeatherStream(GetCurrentWeatherForCityRequest request,
                                                       IServerStreamWriter<WeatherResponse> responseStream,
                                                       ServerCallContext context)
    {
        try
        {
            var httpClient = _clientFactory.CreateClient();

            for (int i = 0; i < 30; i++)
            {
                if (context.CancellationToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Request was cancelled");
                    break;
                }

                var temperatures = await GetCurrentTemperaturesAsync(request, httpClient);
                await responseStream.WriteAsync(new WeatherResponse
                {
                    Temperature = temperatures!.Main.Temp,
                    FeelsLike = temperatures.Main.FeelsLike,
                    Timestamp = Timestamp.FromDateTime(DateTime.UtcNow)
                });
                await Task.Delay(1000);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public override async Task<MultiweatherResponse> GetMultiCurrentWeatherStream(IAsyncStreamReader<GetCurrentWeatherForCityRequest> requestStream,
                                                                                  ServerCallContext context)
    {
        var httpClient = _clientFactory.CreateClient();
        var response = new MultiweatherResponse
        {
            Weather = { }
        };

        await foreach (var request in requestStream.ReadAllAsync())
        {
            var temperatures = await GetCurrentTemperaturesAsync(request, httpClient);
            response.Weather.Add(new WeatherResponse
            {
                Temperature = temperatures!.Main.Temp,
                FeelsLike = temperatures.Main.FeelsLike,
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),
                City = request.City,
                Units = request.Units
            });
        }

        return response;
    }

    private static async Task<OpenWeatherContracts> GetCurrentTemperaturesAsync(GetCurrentWeatherForCityRequest request,
                                                                                HttpClient httpClient)
    {
        var responseString = await httpClient.GetStringAsync(
            $"https://api.openweathermap.org/data/2.5/weather?q={request.City}&appid={ApiKey}&units={request.Units}");

        var temperatures = JsonConvert.DeserializeObject<OpenWeatherContracts>(responseString);
        return temperatures;
    }

    public override async Task<Empty> PrintStream(IAsyncStreamReader<PrintRequest> requestStream,
                                                  ServerCallContext context)
    {
        await foreach (var request in requestStream.ReadAllAsync())
        {
            _logger.LogInformation("Client said:" + request.Message);
        }

        return new();
    }
}
