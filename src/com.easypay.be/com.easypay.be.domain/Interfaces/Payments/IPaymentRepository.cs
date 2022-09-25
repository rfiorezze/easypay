using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.easypay.be.domain.Interfaces.Payments
{
    public interface IPaymentRepository
    {
        Task<Guid> RegisterPaymentAsync(Payment payment);

        Task<Payment> GetPaymentAsync(Guid transactionId);

        Task<IEnumerable<Payment>> GetPaymentsByCustomerAsync(Guid clientId);

        Task<IEnumerable<Payment>> GetPaymentsByCustomerAndDateAsync(Guid clientId, DateTime startDate, DateTime endDate);

        void ValidatePayment(Guid transactionId, bool isApproved, string description);
    }
}
