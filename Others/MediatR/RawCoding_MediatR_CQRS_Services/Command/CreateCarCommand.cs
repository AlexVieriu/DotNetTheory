namespace RawCoding_MediatR_CQRS_Services.Command;

public class CreateCarCommand : IRequest<Response<Car>> { }

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Response<Car>>
{
    public Task<Response<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        if(false)
        {
            return Task.FromResult(Response.Fail<Car>(null, "already exists"));
        }

        return Task.FromResult(Response.Ok(new Car { Name = "Mazda"}, "Car Created"));
    }

}
