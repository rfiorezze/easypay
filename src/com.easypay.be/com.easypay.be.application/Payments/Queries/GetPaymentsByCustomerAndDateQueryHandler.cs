using com.easypay.be.application.Payments.Queries.Dtos;
using com.easypay.be.domain.Interfaces.Payments;
using MediatR;

namespace com.easypay.be.application.Payments.Queries
{
    public class GetPaymentsByCustomerAndDateQueryHandler : IRequestHandler<GetPaymentsByCustomerAndDateQueryRequest, GetPaymentsByCustomerAndDateQueryResponse>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentsByCustomerAndDateQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<GetPaymentsByCustomerAndDateQueryResponse> Handle(GetPaymentsByCustomerAndDateQueryRequest request, CancellationToken cancellationToken)
        {
            var getPayments = await _paymentRepository.GetPaymentsByCustomerAndDateAsync(
                clientId: request.ClientId,
                startDate: request.StartDate,
                endDate: request.EndDate);

            if (getPayments is null)
                return null;

            return new GetPaymentsByCustomerAndDateQueryResponse(
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
