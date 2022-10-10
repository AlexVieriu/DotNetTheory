namespace RawCoding_MediatR_CQRS.Infrastructure
{
    public interface IUserIdPipe<TIn, TOut>
    {
        Task<TOut> Handle(TIn request, RequestHandlerDelegate<TOut> next, CancellationToken cancellationToken);
    }
}