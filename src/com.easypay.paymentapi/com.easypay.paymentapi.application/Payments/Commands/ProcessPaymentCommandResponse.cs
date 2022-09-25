using com.easypay.paymentapi.application.Payments.Queries.Dtos;

namespace com.easypay.paymentapi.application.Payments.Commands
{
    public class ProcessPaymentCommandResponse
    {
        public bool IsApproved { get; }

        public string Description { get; }

        public ProcessPaymentCommandResponse(bool isApproved, string description)
        {
            IsApproved = isApproved;
            Description = description;
        }
    }
}
