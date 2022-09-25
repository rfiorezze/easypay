using MediatR;

namespace com.easypay.be.application.Clients.Queries
{
    public class GetClientQueryRequest : IRequest<GetClientQueryResponse>
    {
        public Guid ClientId { get; }

        public GetClientQueryRequest(Guid id)
        {
            ClientId = id;
        }
    }
}
