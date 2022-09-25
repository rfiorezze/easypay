namespace com.easypay.be.api.WorkerServices.Dtos
{
    public class ResponsePaymentDto
    {
        public Guid TransactionId { get; set; }

        public bool IsApproved { get; set; }

        public string Description { get; set; }
    }
}
