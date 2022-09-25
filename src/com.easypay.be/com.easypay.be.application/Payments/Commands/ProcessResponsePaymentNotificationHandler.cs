using com.easypay.be.domain.Interfaces.Payments;
using MediatR;

namespace com.easypay.be.application.Payments.Commands
{
    public class ProcessResponsePaymentNotificationHandler : INotificationHandler<ProcessResponsePaymentNotification>
    {
        private readonly IPaymentRepository _paymentRepository;

        public ProcessResponsePaymentNotificationHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task Handle(ProcessResponsePaymentNotification notification, CancellationToken cancellationToken)
        {
            _paymentRepository.ValidatePayment(
                transactionId: notification.TransactionId,
                isApproved: notification.IsApproved,
                description: notification.Description);

            return Task.CompletedTask;
        }
    }
}
