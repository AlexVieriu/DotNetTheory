namespace HttpClientFactoryHowToUse.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly HttpClient _httpClient;

    public HomeController(IHttpClientFactory clientFactory, HttpClient httpClient)
    {
        // Base Usage and NamedClients
        _clientFactory = clientFactory;

        // TypedClients
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.github.com/");
        _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");
        _httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "HttpRequestsSample");
    }

    [HttpGet]
    public async Task<IActionResult> BasicUsage()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches")
        {
            Headers =
            {
                { HeaderNames.Accept, "application/vnd.github.v3+json" },
                { HeaderNames.UserAgent, "HttpRequestsSample"}
            }
        };

        var httpClient = _clientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(request);

        if (httpResponseMessage.IsSuccessStatusCode is false)
            return BadRequest(httpResponseMessage);

        // Stream classes (FileStream , MemoryStream) are using "using
        // A stream is an abstraction of a sequence of bytes, such as a file,
        // an input/output device, an inter-process communication pipe, or a TCP/IP socket
        using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

        var result = await JsonSerializer.DeserializeAsync
            <IEnumerable<GitHubBranch>>(contentStream);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> NamedClients()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "repos/dotnet/AspNetCore.Docs/branches");
        var client = _clientFactory.CreateClient("Github");
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode is false)
            return BadRequest(response);

        using var contentStream = await response.Content.ReadAsStreamAsync();

        var result = await JsonSerializer.DeserializeAsync
            <IEnumerable<GitHubBranch>>(contentStream);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> TypedClients()
    {
        var response = _httpClient.GetFromJsonAsync<IEnumerable<GitHubBranch>>(
            "repos/dotnet/AspNetCore.Docs/branches");

        return Ok(response);    
    }
}
