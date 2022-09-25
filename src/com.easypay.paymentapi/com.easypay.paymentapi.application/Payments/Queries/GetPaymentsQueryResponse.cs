using com.easypay.paymentapi.application.Payments.Queries.Dtos;

namespace com.easypay.paymentapi.application.Payments.Queries
{
    public class GetPaymentsQueryResponse
    {
        public IEnumerable<GetPaymentsDto> Payments { get; }

        public GetPaymentsQueryResponse(IEnumerable<GetPaymentsDto> payments)
        {
            Payments = payments;
        }
    }
}
