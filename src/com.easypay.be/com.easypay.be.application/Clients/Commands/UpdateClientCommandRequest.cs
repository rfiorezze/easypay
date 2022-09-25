using com.easypay.be.domain;
using MediatR;

namespace com.easypay.be.application.Clients.Commands
{
    public class UpdateClientCommandRequest: IRequest<UpdateClientCommandResponse>
    {
        public Guid Id { get;}
        public string Name { get; }

        public string Agency { get; }

        public string Account { get; }

        public string Bank { get; }

        public UpdateClientCommandRequest(Guid id, string name, string agency, string account, string bank)
        {
            Id = id;
            Name = name;
            Agency = agency;
            Account = account;
            Bank = bank;
        }
    }
}