using System.ComponentModel.DataAnnotations;

namespace com.easypay.be.api.Controllers.Payment.Dtos
{
    public class ProcessPaymentRequestDto
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public string CardHolderName  { get; set; }

        [Required]
        public string SecurityCode { get; set; }

        [Required]
        public string CpfHolder { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public decimal Ammount { get; set; }

        [Required]
        public Guid ClientId { get; set; }
    }
}
