namespace HttpClientFactoryHowToUse.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly GitHubService _gitHubService;
    private readonly IGitHubClient _gitHubClient;

    public HomeController(IHttpClientFactory clientFactory,
                          GitHubService gitHubService,
                          IGitHubClient gitHubClient)
    {
        // Base Usage and NamedClients
        _clientFactory = clientFactory;
        _gitHubService = gitHubService;
        _gitHubClient = gitHubClient;
    }

    [HttpGet("BasicUsage")]
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

    [HttpGet("NamedClients")]
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

    [HttpGet("TypedClients")]
    public async Task<IActionResult> TypedClients()
    {
        var response = await _gitHubService.GetBranches();

        return Ok(response);
    }

    [HttpGet("GeneralClients")]
    public async Task<IActionResult> GeneralClients()
    {
        try
        {
            var result = await _gitHubClient.GetBranchesAsync();

            return Ok(result);
        }
        catch (ApiException)
        {
            throw;
        }
    }
}
