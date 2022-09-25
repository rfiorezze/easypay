using com.easypay.paymentapi.application.Payments.Queries.Dtos;
using com.easypay.paymentapi.domain.Payments.Interfaces;
using MediatR;

namespace com.easypay.paymentapi.application.Payments.Queries
{
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQueryRequest, GetPaymentsQueryResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        public GetPaymentsQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<GetPaymentsQueryResponse> Handle(GetPaymentsQueryRequest request, CancellationToken cancellationToken)
        {
            var getPayments = await _paymentRepository.GetPaymentsAsync(request.StartDate, request.EndDate);

            if (getPayments is null)
                return null;

            return new GetPaymentsQueryResponse(
                getPayments.Select(p =>
                    new GetPaymentsDto(
                        transactionId: p.Id,
                        cardHolderName: p.CardHolderName,
                        ammount: p.Ammount,
                        transactionDate: p.TransactionDate,
                        isApproved: p.IsApproved)));

        }
    }
}
