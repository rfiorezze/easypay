using MediatR;

namespace com.easypay.be.application.Payments.Commands
{
    public class ProcessPaymentCommandRequest : IRequest<ProcessPaymentCommandResponse>
    {
        public string CardNumber { get; }

        public DateTime DueDate { get; }

        public string CardHolderName { get;  }

        public string SecurityCode { get; }

        public string CpfHolder { get; }

        public string Address { get; }

        public decimal Ammount { get; }

        public Guid ClientId { get; }

        public ProcessPaymentCommandRequest(
            string cardNumber,
            DateTime dueDate,
            string cardHolderName,
            string securityCode,
            string cpfHolder,
            string address,
            decimal ammount,
            Guid clientId)
        {
            CardNumber = cardNumber;
            DueDate = dueDate;
            CardHolderName = cardHolderName;
            SecurityCode = securityCode;
            CpfHolder = cpfHolder;
            Address = address;
            Ammount = ammount;
            ClientId = clientId;
        }
    }
}
