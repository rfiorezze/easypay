namespace com.easypay.be.domain
{
    public class Payment
    {
        public string CardNumber { get; set; }

        public DateTime? DueDate { get; set; }

        public string CardHolderName { get; set; }

        public string SecurityCode { get; set; }

        public string CpfHolder { get; set; }

        public string Address { get; set; }

        public decimal Ammount { get; set; }

        public Guid TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public bool IsApproved { get; set; }

        public string Description { get; set; }

        public Guid ClientId { get; set; }

        public Payment(
            string cardNumber,
            DateTime? dueDate,
            string cardHolderName,
            string securityCode,
            string cpfHolder,
            string address,
            decimal ammount,
            Guid transactionId,
            DateTime transactionDate,
            bool isApproved,
            string description,
            Guid clientId)
        {
            CardNumber = cardNumber;
            DueDate = dueDate;
            CardHolderName = cardHolderName;
            SecurityCode = securityCode;
            CpfHolder = cpfHolder;
            Address = address;
            Ammount = ammount;
            TransactionId = transactionId;
            TransactionDate = transactionDate;
            IsApproved = isApproved;
            Description = description;
            ClientId = clientId;
        }

        public static Payment Register(
            string cardHolderName,
            decimal ammount,
            Guid transactionId,
            DateTime transactionDate,
            Guid clientId)
        {
            return new Payment(
                cardNumber: null,
                dueDate: null,
                cardHolderName: cardHolderName,
                securityCode: null,
                cpfHolder: null,
                address: null,
                ammount: ammount,
                transactionId: transactionId,
                transactionDate: transactionDate,
                isApproved: false,
                description: null,
                clientId: clientId);
        }

        public static Payment Get(
            Guid transactionId,
            string cardHolderName,
            decimal ammount,
            bool isApproved,
            DateTime transactionDate,
            string description)
        {
            return new Payment(
                cardNumber: null,
                dueDate: null,
                cardHolderName: cardHolderName,
                securityCode: null,
                cpfHolder: null,
                address: null,
                ammount: ammount,
                transactionId: transactionId,
                transactionDate: transactionDate,
                isApproved: isApproved,
                description: description,
                clientId: Guid.Empty);
        }

        public static Payment Process(
            string cardNumber,
            DateTime dueDate,
            string cardHolderName,
            string securityCode,
            string cpfHolder,
            string address,
            decimal ammount,
            Guid clientId)
        {
            return new Payment(
                cardNumber: cardNumber,
                dueDate: dueDate,
                cardHolderName: cardHolderName,
                securityCode: securityCode,
                cpfHolder: cpfHolder,
                address: address,
                ammount: ammount,
                transactionId: Guid.NewGuid(),
                transactionDate: DateTime.Now,
                isApproved: false,
                description: null,
                clientId: clientId);
        }
    }
}
