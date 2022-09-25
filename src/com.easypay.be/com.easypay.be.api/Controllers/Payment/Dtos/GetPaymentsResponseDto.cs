namespace com.easypay.be.api.Controllers.Payment.Dtos
{
    public class GetPaymentsResponseDto
    {
        public IEnumerable<GetPaymentsDto> Payments { get; set; }

        public GetPaymentsResponseDto(IEnumerable<GetPaymentsDto> payments)
        {
            Payments = payments;
        }
    }
}
