using System.ComponentModel.DataAnnotations;

namespace com.easypay.be.api.Controllers.Client.Dtos
{
    public class CreateClientRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Agency { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string Bank { get; set; }
    }
}
