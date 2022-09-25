using MediatR;

namespace com.easypay.be.application.Clients.Commands
{
    public class CreateClientCommandRequest: IRequest<CreateClientCommandResponse>
    {
        public string Name { get; }

        public string Agency { get; }

        public string Account { get; }

        public string Bank { get; }

        public CreateClientCommandRequest(string name, string agency, string account, string bank)
        {
            Name = name;
            Agency = agency;
            Account = account;
            Bank = bank;
        }
    }
}