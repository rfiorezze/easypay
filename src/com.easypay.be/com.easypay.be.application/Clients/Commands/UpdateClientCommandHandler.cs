using com.easypay.be.domain;
using com.easypay.be.domain.Interfaces.Clients;
using MediatR;

namespace com.easypay.be.application.Clients.Commands
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommandRequest, UpdateClientCommandResponse>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<UpdateClientCommandResponse> Handle(UpdateClientCommandRequest request, CancellationToken cancellationToken)
        {
            var client = Client.Update(
                request.Id,
                request.Name,
                request.Agency,
                request.Account,
                request.Bank);

            var clientUpdated = await _clientRepository.UpdateAsync(client);

            return new UpdateClientCommandResponse(
                id: clientUpdated.Id,
                name: clientUpdated.Name,
                agency: clientUpdated.Agency,
                account: clientUpdated.Account,
                bank: clientUpdated.Bank);
        }
    }
}