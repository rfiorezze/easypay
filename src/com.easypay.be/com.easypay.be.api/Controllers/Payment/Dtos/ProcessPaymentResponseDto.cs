namespace com.easypay.be.api.Controllers.Payment.Dtos
{
    public class ProcessPaymentResponseDto
    {
        public Guid TransactionId { get; set; }

        public ProcessPaymentResponseDto(Guid transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
