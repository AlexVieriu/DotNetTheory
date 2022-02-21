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

    [HttpGet()]
    [Route("FromRoute/{serie_polita}/{nr_polita}")]
    public IActionResult FromRoute([FromRoute] string serie_polita, [FromRoute] int nr_polita)
    {
        return Ok(new { SeriePolita = serie_polita, Nr_Polita = nr_polita });
    }

    [HttpGet("FromQuery")]
    public IActionResult FromQuery([FromQuery] int id, [FromQuery] string name)
    {
        return Ok(new { IdPerson = id, Name = name });
    }

    [HttpGet("FromHeader")]
    public IActionResult FromHeader([FromHeader] string Accept)
    {
        return Ok($"Header: {Accept}");
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
