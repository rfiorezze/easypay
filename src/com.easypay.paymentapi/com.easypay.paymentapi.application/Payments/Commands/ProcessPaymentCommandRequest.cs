using MediatR;

namespace com.easypay.paymentapi.application.Payments.Commands
{
    public class ProcessPaymentCommandRequest : IRequest<ProcessPaymentCommandResponse>
    {
        public Guid TransactionId { get; }
        public string CardNumber { get; }

        public DateTime? DueDate { get; }

        public string CardHolderName { get; }

        public string SecurityCode { get; }

        public string CpfHolder { get; }

        public string Address { get; }

        public decimal Ammount { get; }

        public DateTime TransactionDate { get; }

        public Guid ClientId { get; }

        public ProcessPaymentCommandRequest(
            Guid transactionId,
            string cardNumber,
            DateTime? dueDate,
            string cardHolderName,
            string securityCode,
            string cpfHolder,
            string address,
            decimal ammount,
            Guid clientId,
            DateTime transactionDate)
        {
            TransactionId = transactionId;
            CardNumber = cardNumber;
            DueDate = dueDate;
            CardHolderName = cardHolderName;
            SecurityCode = securityCode;
            CpfHolder = cpfHolder;
            Address = address;
            Ammount = ammount;
            ClientId = clientId;
            TransactionDate = transactionDate;
        }
    }
}
