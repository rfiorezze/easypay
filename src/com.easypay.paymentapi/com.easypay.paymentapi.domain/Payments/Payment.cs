namespace com.easypay.paymentapi.domain.Payments
{
    public class Payment
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }

        public DateTime DueDate { get; set; }

        public string CardHolderName { get; set; }

        public string SecurityCode { get; set; }

        public string CpfHolder { get; set; }

        public string Address { get; set; }

        public decimal Ammount { get; set; }

        public bool IsApproved { get; set; }

        public DateTime TransactionDate { get; set; }

        public Guid ClientId { get; set; }
    }
}
