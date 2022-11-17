using RawCoding_MediatR_CQRS_Services;
using RawCoding_MediatR_CQRS_Services.Command;

namespace RawCoding_MediatR_CQRS.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<Car>> GetCars()
    {
        return await _mediator.Send(new GetAllCarsQuery());
    }

    [HttpPost]
    public async Task<Response<Car>> CreateCar([FromBody] CreateCarCommand command)
    {
        return await _mediator.Send(command);
    }
}
