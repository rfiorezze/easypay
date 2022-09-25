namespace com.easypay.be.application.Clients.Commands
{
    public class CreateClientCommandResponse
    {
        public Guid Id { get; }

        public CreateClientCommandResponse(Guid id)
        {
            Id = id;
        }
    }
}