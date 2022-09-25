namespace com.easypay.be.application.Payments.Queries
{
    public class GetPaymentQueryResponse
    {
        public Guid TransactionId { get; }

        public string CardHolderName { get; }

        public decimal Ammount { get; }

        public bool IsApproved { get; }

        public string Description { get; }

        public DateTime TransactionDate { get; }

        public GetPaymentQueryResponse(Guid transactionId, string cardHolderName, decimal ammount, bool isApproved, string description, DateTime transactionDate)
        {
            TransactionId = transactionId;
            CardHolderName = cardHolderName;
            Ammount = ammount;
            IsApproved = isApproved;
            Description = description;
            TransactionDate = transactionDate;
        }
    }
}
