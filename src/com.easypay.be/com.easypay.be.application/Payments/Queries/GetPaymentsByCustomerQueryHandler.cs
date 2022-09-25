using com.easypay.be.application.Payments.Queries.Dtos;
using com.easypay.be.domain.Interfaces.Payments;
using MediatR;

namespace com.easypay.be.application.Payments.Queries
{
    public class GetPaymentsByCustomerQueryHandler : IRequestHandler<GetPaymentsByCustomerQueryRequest, GetPaymentsByCustomerQueryResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        public GetPaymentsByCustomerQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<GetPaymentsByCustomerQueryResponse> Handle(GetPaymentsByCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var getPayments = await _paymentRepository.GetPaymentsByCustomerAsync(request.ClientId);

            if (getPayments is null)
                return null;

            return new GetPaymentsByCustomerQueryResponse(
                getPayments.Select(p => new GetPaymentsDto(
                    transactionId: p.TransactionId,
                    cardHolderName: p.CardHolderName,
                    ammount: p.Ammount,
                    isApproved: p.IsApproved,
                    description: p.Description,
                    transactionDate: p.TransactionDate)));
        }
    }
}
