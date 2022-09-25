namespace com.easypay.be.api.Controllers.Payment.Dtos
{
    public class PaymentDto
    {
        public string CardHolderName { get; set; }

        public decimal Ammount { get; set; }

        public DateTime TransactionDate { get; set; }

        public PaymentDto(string cardHolderName, decimal ammount, DateTime transactionDate)
        {
            CardHolderName = cardHolderName;
            Ammount = ammount;
            TransactionDate = transactionDate;
        }
    }
}
