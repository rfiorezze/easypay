using com.easypay.be.domain.Interfaces.Clients;
using MediatR;

namespace com.easypay.be.application.Clients.Queries
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQueryRequest, GetClientQueryResponse>
    {
        private readonly IClientRepository _clientRepository;
        public GetClientQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;                
        }
        public async Task<GetClientQueryResponse> Handle(GetClientQueryRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetAsync(request.ClientId);

            if (client is null)
                return null;

            return new GetClientQueryResponse(
                id: client.Id,
                name: client.Name,
                agency: client.Agency,
                account: client.Account,
                bank: client.Bank);
        }
    }
}
