using com.easypay.be.domain;
using com.easypay.be.domain.Interfaces.Clients;
using MediatR;

namespace com.easypay.be.application.Clients.Commands
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommandRequest, CreateClientCommandResponse>
    {
        private readonly IClientRepository _clientRepository;
        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<CreateClientCommandResponse> Handle(CreateClientCommandRequest request, CancellationToken cancellationToken)
        {
            var client = Client.Create(
                request.Name,
                request.Agency,
                request.Account,
                request.Bank);

            var clientIdCreated = await _clientRepository.CreateAsync(client);

            return new CreateClientCommandResponse(clientIdCreated);
        }
    }
}