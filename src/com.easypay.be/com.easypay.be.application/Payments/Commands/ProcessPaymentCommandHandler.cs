using com.easypay.be.agents.Publishers;
using com.easypay.be.domain;
using com.easypay.be.domain.Interfaces.Payments;
using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace com.easypay.be.application.Payments.Commands
{
    public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommandRequest, ProcessPaymentCommandResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMessageService _messageService;

        public ProcessPaymentCommandHandler(IPaymentRepository paymentRepository, IMessageService messageService)
        {
            _paymentRepository = paymentRepository;
            _messageService = messageService;
        }
        public async Task<ProcessPaymentCommandResponse> Handle(ProcessPaymentCommandRequest request, CancellationToken cancellationToken)
        {
            var paymentForProcess = Payment.Process(
                cardNumber: request.CardNumber,
                dueDate: request.DueDate,
                cardHolderName: request.CardHolderName,
                securityCode: request.SecurityCode,
                cpfHolder: request.CpfHolder,
                address: request.Address,
                ammount: request.Ammount,
                clientId: request.ClientId);

            //Insert message in queue

            _messageService.Enqueue("process-payment", JsonConvert.SerializeObject(paymentForProcess));

            //Register Transaction

            var paymentForRegister = Payment.Register(
                cardHolderName: paymentForProcess.CardHolderName,
                ammount: paymentForProcess.Ammount,
                transactionId: paymentForProcess.TransactionId,
                transactionDate: paymentForProcess.TransactionDate,
                clientId: paymentForProcess.ClientId);

            var transactionId = await _paymentRepository.RegisterPaymentAsync(paymentForRegister);

            return new ProcessPaymentCommandResponse(transactionId);
        }
    }
}
