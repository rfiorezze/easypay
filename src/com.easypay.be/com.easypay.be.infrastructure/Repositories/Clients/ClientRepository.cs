using com.easypay.be.domain.Interfaces.Clients;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Client = com.easypay.be.infrastructure.Models.Clients;

namespace com.easypay.be.infrastructure.Repositories.Clients
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMongoCollection<Client> _client;

        public ClientRepository(IConfiguration config)
        {
            var connectionString = config.GetSection("MongoDBSettings").GetSection("ConnectionString").Value;
            var databaseName = config.GetSection("MongoDBSettings").GetSection("DatabaseName").Value;
            var db = new MongoClient(connectionString)
                .GetDatabase(databaseName);
            _client = db.GetCollection<Client>("Clients");
        }

        public async Task<Guid> CreateAsync(domain.Client client)
        {
            var clientModel = new Client
            {
                Id = client.Id.ToString(),
                Name = client.Name,
                Account = client.Account,
                Agency = client.Agency,
                Bank = client.Bank
            };

            await _client
                .InsertOneAsync(clientModel);

            return client.Id;
        }

        public async Task<domain.Client> UpdateAsync(domain.Client client)
        {
            var clientModel = new Client
            {
                Id = client.Id.ToString(),
                Name = client.Name,
                Account = client.Account,
                Agency = client.Agency,
                Bank = client.Bank
            };

            await _client
                .ReplaceOneAsync(c => c.Id == clientModel.Id, clientModel);

            return client;
        }

        public async Task<domain.Client> GetAsync(Guid clientId)
        {
            var resultGet = await _client.Find(c => c.Id == clientId.ToString()).FirstOrDefaultAsync();

            if (resultGet is null)
                return null;

            return new domain.Client(
                id: Guid.Parse(resultGet.Id),
                name: resultGet.Name,
                agency: resultGet.Agency,
                account: resultGet.Account,
                bank: resultGet.Bank);
        }
    }
}
