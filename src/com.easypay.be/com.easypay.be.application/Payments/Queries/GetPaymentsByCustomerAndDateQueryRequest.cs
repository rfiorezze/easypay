using MediatR;

namespace com.easypay.be.application.Payments.Queries
{
    public class GetPaymentsByCustomerAndDateQueryRequest : IRequest<GetPaymentsByCustomerAndDateQueryResponse>
    {
        public Guid ClientId { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public GetPaymentsByCustomerAndDateQueryRequest(Guid clientId, DateTime startDate, DateTime endDate)
        {
            ClientId = clientId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
