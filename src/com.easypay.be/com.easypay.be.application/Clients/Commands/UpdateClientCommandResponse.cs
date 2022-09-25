namespace com.easypay.be.application.Clients.Commands
{
    public class UpdateClientCommandResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Agency { get; set; }

        public string Account { get; set; }

        public string Bank { get; set; }

        public UpdateClientCommandResponse(Guid id, string name, string agency, string account, string bank)
        {
            Id = id;
            Name = name;
            Agency = agency;
            Account = account;
            Bank = bank;
        }
    }
}