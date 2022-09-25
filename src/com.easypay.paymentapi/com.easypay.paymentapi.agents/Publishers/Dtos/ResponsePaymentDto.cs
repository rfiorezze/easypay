namespace com.easypay.paymentapi.agents.Publishers.Dtos
{
    public class ResponsePaymentDto
    {
        public Guid TransactionId { get; set; }

        public bool IsApproved { get; set; }

        public string Description { get; set; }

        public ResponsePaymentDto(Guid transactionId, bool isApproved, string description)
        {
            TransactionId = transactionId;
            IsApproved = isApproved;
            Description = description;
        }
    }
}
