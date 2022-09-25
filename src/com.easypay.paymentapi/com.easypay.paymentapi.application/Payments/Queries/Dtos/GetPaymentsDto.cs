using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.easypay.paymentapi.application.Payments.Queries.Dtos
{
    public class GetPaymentsDto
    {
        public Guid TransactionId { get; set; }

        public string CardHolderName { get; set; }

        public decimal Ammount { get; set; }

        public bool IsApproved { get; set; }

        public DateTime TransactionDate { get; set; }

        public GetPaymentsDto(Guid transactionId, string cardHolderName, decimal ammount, DateTime transactionDate, bool isApproved)
        {
            TransactionId = transactionId;
            CardHolderName = cardHolderName;
            Ammount = ammount;
            TransactionDate = transactionDate;
            IsApproved = isApproved;
        }
    }
}
