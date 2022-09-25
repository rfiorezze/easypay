namespace com.easypay.be.domain
{
    public class Client
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Agency { get; set; }

        public string Account { get; set; }

        public string Bank { get; set; }

        public Client(Guid id, string name, string agency, string account, string bank)
        {
            Id = id;
            Name = name;
            Agency = agency;
            Account = account;
            Bank = bank;
        }

        public static Client Create(string name, string agency, string account, string bank)
        {
            return new Client(
                id: Guid.NewGuid(),
                name: name,
                agency: agency,
                account: account,
                bank: bank);
        }

        public static Client Update(Guid id, string name, string agency, string account, string bank)
        {
            return new Client(
                id: id,
                name: name,
                agency: agency,
                account: account,
                bank: bank);
        }
    }
}
