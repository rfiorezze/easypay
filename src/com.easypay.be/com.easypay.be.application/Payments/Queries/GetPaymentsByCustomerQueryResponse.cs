using com.easypay.be.application.Payments.Queries.Dtos;

namespace com.easypay.be.application.Payments.Queries
{
    public class GetPaymentsByCustomerQueryResponse
    {
        public IEnumerable<GetPaymentsDto> Payments { get; }

        public GetPaymentsByCustomerQueryResponse(IEnumerable<GetPaymentsDto> payments)
        {
            Payments = payments;
        }
    }
}
