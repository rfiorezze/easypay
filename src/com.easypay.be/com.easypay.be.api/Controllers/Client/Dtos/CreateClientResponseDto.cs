namespace com.easypay.be.api.Controllers.Client.Dtos
{
    public class CreateClientResponseDto
    {
        public Guid Id { get; set; }

        public CreateClientResponseDto(Guid id)
        {
            Id = id;
        }
    }
}
