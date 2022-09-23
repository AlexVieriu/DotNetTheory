using Microsoft.AspNetCore.Mvc;

namespace RawCoding_HttpClient.API.Controllers;

[ApiController]
[Route("homes")]
public class HomeController : ControllerBase
{
    [HttpGet("{guid}")]
    public object Index(string guid)
    {
        return new { 
            Name = guid, 
            StartUpHeader = Request.Headers["StartUpHeader"],
            CtorHeader = Request.Headers["Middleware-Ctor"],
            MethodHeader = Request.Headers["Middleware-Method"]
        };
    }
}
