using MediatR;

namespace com.easypay.be.application.Payments.Queries
{
    public class GetPaymentsByCustomerQueryRequest : IRequest<GetPaymentsByCustomerQueryResponse>
    {
        public Guid ClientId { get; }

        public GetPaymentsByCustomerQueryRequest(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
