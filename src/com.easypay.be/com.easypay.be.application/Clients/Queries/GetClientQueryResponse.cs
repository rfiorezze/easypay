namespace com.easypay.be.application.Clients.Queries
{
    public class GetClientQueryResponse
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Agency { get; }

        public string Account { get; }

        public string Bank { get; }

        public GetClientQueryResponse(Guid id, string name, string agency, string account, string bank)
        {
            Id = id;
            Name = name;
            Agency = agency;
            Account = account;
            Bank = bank;
        }
    }
}
