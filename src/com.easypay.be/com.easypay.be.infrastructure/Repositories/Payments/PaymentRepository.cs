using com.easypay.be.domain.Interfaces.Payments;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Payment = com.easypay.be.infrastructure.Models.Payments;

namespace com.easypay.be.infrastructure.Repositories.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IMongoCollection<Payment> _payment;

        public PaymentRepository(IConfiguration config)
        {
            var connectionString = config.GetSection("MongoDBSettings").GetSection("ConnectionString").Value;
            var databaseName = config.GetSection("MongoDBSettings").GetSection("DatabaseName").Value;
            var db = new MongoClient(connectionString)
                .GetDatabase(databaseName);
            _payment = db.GetCollection<Payment>("Payments");
        }
        public async Task<domain.Payment> GetPaymentAsync(Guid transactionId)
        {
            var paymentGet = await _payment
                .Find(p => p.Id == transactionId.ToString())
                .FirstOrDefaultAsync();

            if (paymentGet is null)
                return null;

            return domain.Payment.Get(
                transactionId: transactionId,
                cardHolderName: paymentGet.CardHolderName,
                ammount: paymentGet.Ammount,
                isApproved: paymentGet.IsApproved,
                transactionDate: Convert.ToDateTime(paymentGet.TransactionDate),
                description: paymentGet.Description);
        }

        public async Task<IEnumerable<domain.Payment>> GetPaymentsByCustomerAndDateAsync(Guid clientId, DateTime startDate, DateTime endDate)
        {
            var paymentsGet = await _payment
                .Find(p =>
                p.ClientId == clientId.ToString()
                && p.TransactionDate >= startDate
                && p.TransactionDate <= endDate)
                .ToListAsync();

            if (!paymentsGet.Any())
                return null;

            var paymentsResponse = paymentsGet.Select(p =>
                domain.Payment.Get(
                    transactionId: Guid.Parse(p.Id),
                    cardHolderName: p.CardHolderName,
                    ammount: p.Ammount,
                    isApproved: p.IsApproved,
                    transactionDate: Convert.ToDateTime(p.TransactionDate),
                    description: p.Description));

            return paymentsResponse;
        }

        public async Task<IEnumerable<domain.Payment>> GetPaymentsByCustomerAsync(Guid clientId)
        {
            var paymentsGet = await _payment
                .Find(p =>
                p.ClientId == clientId.ToString())
                .ToListAsync();

            if (!paymentsGet.Any())
                return null;

            var paymentsResponse = paymentsGet.Select(p =>
                domain.Payment.Get(
                    transactionId: Guid.Parse(p.Id),
                    cardHolderName: p.CardHolderName,
                    ammount: p.Ammount,
                    isApproved: p.IsApproved,
                    transactionDate: Convert.ToDateTime(p.TransactionDate),
                    description: p.Description));

            return paymentsResponse;
        }

        public async Task<Guid> RegisterPaymentAsync(domain.Payment payment)
        {
            var paymentModel = new Payment
            {
                Id = payment.TransactionId.ToString(),
                CardHolderName = payment.CardHolderName,
                ClientId = payment.ClientId.ToString(),
                TransactionDate = payment.TransactionDate,
                Ammount = payment.Ammount
            };

            await _payment.InsertOneAsync(paymentModel);

            return payment.TransactionId;
        }

        public void ValidatePayment(Guid transactionId, bool isApproved, string description)
        {
            var payment = _payment
                .Find(p => p.Id == transactionId.ToString())
                .FirstOrDefault();

            payment.Description = description;
            payment.IsApproved = isApproved;

            _payment
                .ReplaceOne(c => c.Id == payment.Id, payment);
        }
    }
}
