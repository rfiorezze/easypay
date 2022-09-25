using com.easypay.be.domain.Interfaces.Payments;
using MediatR;

namespace com.easypay.be.application.Payments.Queries
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQueryRequest, GetPaymentQueryResponse>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<GetPaymentQueryResponse> Handle(GetPaymentQueryRequest request, CancellationToken cancellationToken)
        {
            var getPayment = await _paymentRepository.GetPaymentAsync(request.TransactionId);

            if (getPayment is null)
                return null;

            return new GetPaymentQueryResponse(
                transactionId: request.TransactionId,
                cardHolderName: getPayment.CardHolderName,
                ammount: getPayment.Ammount,
                isApproved: getPayment.IsApproved,
                description: getPayment.Description,
                transactionDate: getPayment.TransactionDate);
        }
    }
}
