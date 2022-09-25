using com.easypay.paymentapi.domain.Payments.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Payment = com.easypay.paymentapi.infrastructure.Models.Payments;
namespace com.easypay.paymentapi.infrastructure.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IMongoCollection<Payment> _payments;

        public PaymentRepository(IConfiguration config)
        {
            var connectionString = config.GetSection("MongoDBSettings").GetSection("ConnectionString").Value;
            var databaseName = config.GetSection("MongoDBSettings").GetSection("DatabaseName").Value;
            var db = new MongoClient(connectionString)
                .GetDatabase(databaseName);
            _payments = db.GetCollection<Payment>("Payments");
        }
        public async Task<bool> ProcessPayment(domain.Payments.Payment payment)
        {
            bool isApproved = false;

            var paymentModel = new Payment
            {
                Id = payment.Id.ToString(),
                Ammount = payment.Ammount,
                CardHolderName = payment.CardHolderName,
                TransactionDate = payment.TransactionDate,
                IsApproved = true
            };

            await _payments.InsertOneAsync(paymentModel);

            return paymentModel.IsApproved;
        }

        public async Task<IEnumerable<domain.Payments.Payment>> GetPaymentsAsync(DateTime startDate, DateTime endDate)
        {
            var paymentsGet = await _payments
                .Find(p =>
                p.TransactionDate >= startDate
                && p.TransactionDate <= endDate)
                .ToListAsync();

            if (!paymentsGet.Any())
                return null;

            var paymentsResponse = paymentsGet.Select(p =>
                new domain.Payments.Payment
                {
                    Ammount = p.Ammount,
                    CardHolderName = p.CardHolderName,
                    TransactionDate = p.TransactionDate,
                    Id = Guid.Parse(p.Id),
                    IsApproved = p.IsApproved
                });

            return paymentsResponse;
        }
    }
}