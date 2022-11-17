
namespace RawCoding_MediatR_CQRS_Services.Cars.Queries;

public class GetAllCarsQuery : BaseRequest, IRequest<IEnumerable<Car>>
{

}

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
{
    // do Dependency injection here if needed
    public GetAllCarsQueryHandler()
    {

    }

    public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new List<Car>
        {
            new Car{ Name = $"Ford + {request.UserId}"},
            new Car{ Name = "Toyota"}
        });
    }
}
