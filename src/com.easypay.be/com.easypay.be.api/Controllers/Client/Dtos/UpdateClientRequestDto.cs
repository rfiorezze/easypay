using System.ComponentModel.DataAnnotations;

namespace com.easypay.be.api.Controllers.Client.Dtos
{
    public class UpdateClientRequestDto
    {
        [Required]
        public string Agency { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string Bank { get; set; }

        [Required]
        public string KeyPix { get; set; }
    }
}
