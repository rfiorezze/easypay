namespace com.easypay.be.application.Payments.Commands
{
    public class ProcessPaymentCommandResponse
    {
        public Guid TransactionId { get; }

        public ProcessPaymentCommandResponse(Guid transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
