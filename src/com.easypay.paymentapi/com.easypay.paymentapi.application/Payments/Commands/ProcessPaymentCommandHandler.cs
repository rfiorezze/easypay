using com.easypay.paymentapi.domain.Payments;
using com.easypay.paymentapi.domain.Payments.Interfaces;
using MediatR;

namespace com.easypay.paymentapi.application.Payments.Commands
{
    public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommandRequest, ProcessPaymentCommandResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        public ProcessPaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<ProcessPaymentCommandResponse> Handle(ProcessPaymentCommandRequest request, CancellationToken cancellationToken)
        {
            //Call the External Entitie here


            //Register Payment
            var payment = new Payment
            {
                Id = request.TransactionId,
                Ammount = request.Ammount,
                TransactionDate = request.TransactionDate,
                CardHolderName = request.CardHolderName
            };

            var isApproved = await _paymentRepository.ProcessPayment(payment);
            var description = isApproved is true ? "Pagamento Aprovado!" : "Pagamento não Aprovado!";

            return new ProcessPaymentCommandResponse(isApproved, description);
        }
    }
}
