using Api_FromAttributes.Models;
using Microsoft.AspNetCore.Mvc;

namespace FromAttributes_API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly IPersonServices _person;

    public HomeController(IPersonServices person)
    {
        _person = person;
    }

    [HttpGet("FromRoute/{id:int}")]    
    public IActionResult FromRoute([FromRoute] int id)
    {
        return Ok(new { IdPerson = id });
    }

    [HttpGet("FromQuery")]
    public IActionResult FromQuery([FromQuery] int id, [FromQuery] string name)
    {
        return Ok(new { IdPerson = id, Name = name });
    }

    [HttpGet("FromHeader")]
    public IActionResult FromHeader([FromHeader] string cookie)
    {
        return Ok($"Header: {cookie}");
    }

    [HttpGet("FromHeader2")]
    public IActionResult FromHeader2([FromHeader(Name = "User-Agent")] string something)
    {
        return Ok($"Header: {something}");
    }

    [HttpGet("FromBody")]
    public IActionResult FromBody([FromBody] Person person)
    {
        return Ok(person);
    }

    [HttpGet("FromForm")]
    public IActionResult FromForm([FromForm] Person person)
    {
        return Ok(person);
    }
}
