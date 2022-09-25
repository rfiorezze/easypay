using System.ComponentModel.DataAnnotations;

namespace com.easypay.be.api.Controllers.Client.Dtos
{
    public class ClientResponseDto
    {
        public Guid Id { get; set; }

        public string Agency { get; set; }

        public string Account { get; set; }

        public string Bank { get; set; }

        public ClientResponseDto(Guid id, string agency, string account, string bank)
        {
            Id = id;
            Agency = agency;
            Account = account;
            Bank = bank;
        }
    }
}
