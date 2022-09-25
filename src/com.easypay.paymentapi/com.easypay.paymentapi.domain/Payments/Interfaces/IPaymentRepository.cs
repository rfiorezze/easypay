namespace com.easypay.paymentapi.domain.Payments.Interfaces
{
    public interface IPaymentRepository
    {
        Task<bool> ProcessPayment(Payment payment);

        Task<IEnumerable<Payment>> GetPaymentsAsync(DateTime startDate, DateTime endDate);
    }
}
