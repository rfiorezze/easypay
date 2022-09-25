using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.easypay.be.domain.Interfaces.Clients
{
    public interface IClientRepository
    {
        Task<Guid> CreateAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task<Client> GetAsync(Guid clientId);
    }
}
