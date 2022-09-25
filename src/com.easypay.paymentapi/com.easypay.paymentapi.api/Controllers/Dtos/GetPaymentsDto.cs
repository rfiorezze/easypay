namespace com.easypay.paymentapi.api.Controllers.Dtos
{
    public class GetPaymentsDto
    {
        public IEnumerable<PaymentsDto> Payments { get; set; }

        public GetPaymentsDto(IEnumerable<PaymentsDto> payments)
        {
            Payments = payments;
        }
    }
}
