using Microsoft.AspNetCore.Mvc;
using RawCoding_HttpClient.Consumer.Client;

namespace RawCoding_HttpClient.Consumer.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : Controller
{

    [HttpGet("bad")]
    public async Task<string> Bad()
    {
        var client = new HttpClient() { BaseAddress = new Uri("https://localhost:7087") };

        return await client.GetStringAsync($"/homes/{Guid.NewGuid()}");
    }

    [HttpGet("simple")]
    public async Task<string> Simple([FromServices] IHttpClientFactory factory)
    {
        var client = factory.CreateClient("simple");

        return await client.GetStringAsync($"/homes/{Guid.NewGuid()}");
    }

    [HttpGet("type")]
    public async Task<string> Type([FromServices] CustomHttpClient client)
    {
        return await client.GetHome();
    }
}
