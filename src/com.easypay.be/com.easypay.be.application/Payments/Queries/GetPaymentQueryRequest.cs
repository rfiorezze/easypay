using MediatR;

namespace com.easypay.be.application.Payments.Queries
{
    public class GetPaymentQueryRequest: IRequest<GetPaymentQueryResponse>
    {
        public Guid TransactionId { get; }

        public GetPaymentQueryRequest(Guid transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
