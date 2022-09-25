using MediatR;

namespace com.easypay.be.application.Payments.Commands
{
    public class ProcessResponsePaymentNotification : INotification
    {
        public Guid TransactionId { get; }

        public bool IsApproved { get;  }

        public string Description { get; }

        public ProcessResponsePaymentNotification(
            Guid transactionId,
            bool isApproved,
            string description)
        {
            TransactionId = transactionId;
            IsApproved = isApproved;
            Description = description;
        }
    }
}
