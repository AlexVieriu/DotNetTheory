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
    [Route("EX1/{serie_polita}/{nr_polita}")]
    public IActionResult FromRoute([FromRoute] string serie_polita, [FromRoute] int nr_polita)
    {
        return Ok(new { SeriePolita = serie_polita, Nr_Polita = nr_polita });
    }

    [HttpGet("EX2")]
    public IActionResult FromQuery([FromQuery] int id, [FromQuery] string name)
    {
        return Ok(new { IdPerson = id, Name = name });
    }

    [HttpGet("EX3")]
    public IActionResult FromHeader([FromHeader] string seriePolita)
    {
        return Ok($"Header: {seriePolita}");
    }

    [HttpGet("EX4")]
    public IActionResult FromHeader2([FromHeader(Name = "User-Agent")] string something)
    {
        return Ok($"Header: {something}");
    }

    [HttpPost("EX5")]
    public IActionResult FromBody([FromBody] Person person)
    {
        return Ok(person);
    }

    [HttpPost("EX6")]
    public IActionResult FromForm([FromForm] Person person)
    {
        return Ok(person);
    }
}
