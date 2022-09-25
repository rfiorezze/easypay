using MediatR;
using System.Net;

namespace com.easypay.paymentapi.application.Payments.Queries
{
    public class GetPaymentsQueryRequest : IRequest<GetPaymentsQueryResponse>
    {
        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public GetPaymentsQueryRequest(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
