namespace RawCoding_MediatR_CQRS.Infrastructure;

public class UserIdPipe<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IHttpContextAccessor _accessor;

    public UserIdPipe(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is BaseRequest br)
        {
            br.UserId = "woop";
        }

        var result = await next();

        if (result is Response<Car> carResponse)
        {
            carResponse.Data.Name += " CHECKED";
        }

        return result;
    }
}
