using Api_FromAttributes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_FromAttributes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _person;

        public PersonController(IPersonServices person)
        {
            _person = person;
        }

        [HttpGet("{id:int}")]
        [Route("/FromRoute")]
        public IActionResult FromRoute([FromRoute] int id)
        {
            return Ok(new { IdPerson = id });
        }

        [HttpGet]
        [Route("/FromQuery")]
        public IActionResult FromQuery([FromQuery] int id, [FromQuery] string name)
        {
            return Ok(new { IdPerson = id, Name = name });
        }

        [HttpGet]
        [Route("/FromHeader")]
        public IActionResult FromHeader([FromHeader] string cookie)
        {
            return Ok($"Header: {cookie}");
        }

        [HttpGet]
        [Route("/FromHeader2")]
        public IActionResult FromHeader2([FromHeader(Name = "User-Agent")] string something )
        {
            return Ok($"Header: {something}");
        }

        [HttpGet]
        [Route("/FromBody")]        
        public IActionResult FromBody([FromBody] Person person)
        {
            return Ok(person);
        }

        [HttpGet]
        [Route("/FromForm")]
        public IActionResult FromForm([FromForm] Person person)
        {
            return Ok(person);
        }
    }
}
