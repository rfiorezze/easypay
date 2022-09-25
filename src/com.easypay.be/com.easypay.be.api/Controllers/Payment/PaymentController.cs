using com.easypay.be.api.Controllers.Payment.Dtos;
using com.easypay.be.api.Dtos;
using com.easypay.be.application.Payments.Commands;
using com.easypay.be.application.Payments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace com.easypay.be.api.Controllers.Payment
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IMediator _mediator;

        public PaymentController(
            ILogger<PaymentController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("ProcessPayment")]
        [Consumes("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.Created, type: typeof(ProcessPaymentResponseDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(ErrorDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError, type: typeof(ErrorDto))]
        public async Task<IActionResult> ProcessPaymentAsync([FromBody] ProcessPaymentRequestDto request)
        {
            var processPaymentCommandRequest = new ProcessPaymentCommandRequest(
                cardNumber: request.CardNumber,
                dueDate: request.DueDate,
                cardHolderName: request.CardHolderName,
                securityCode: request.SecurityCode,
                cpfHolder: request.CpfHolder,
                address: request.Address,
                ammount: request.Ammount,
                clientId: request.ClientId);

            try
            {
                var response = await _mediator.Send(processPaymentCommandRequest);

                var processedPayment = new ProcessPaymentResponseDto(response.TransactionId);

                return StatusCode(
                    statusCode: (int)HttpStatusCode.Created,
                    value: processedPayment);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    value: new ErrorDto(ex.Message));
            }
        }

        [HttpGet("GetPayment")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(PaymentDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetPaymentAsync([FromQuery] Guid transactionId)
        {
            var getPaymentRequest = new GetPaymentQueryRequest(transactionId);

            try
            {
                var payment = await _mediator.Send(getPaymentRequest);

                if (payment is null)
                {
                    return StatusCode(
                        statusCode: (int)HttpStatusCode.NotFound,
                        value: new ErrorDto("Payment Not Found."));
                }

                return Ok(new GetPaymentsDto(
                    transactionId: payment.TransactionId,
                    isApproved: payment.IsApproved,
                    cardHolderName: payment.CardHolderName,
                    ammount: payment.Ammount,
                    transactionDate: payment.TransactionDate));
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    value: new ErrorDto(ex.Message));
            }
        }

        [HttpGet("GetPaymentsByCustomer")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(GetPaymentsResponseDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetPaymentsByCustomerAsync([FromQuery] Guid clientId)
        {
            var getPaymentsRequest = new GetPaymentsByCustomerQueryRequest(clientId);

            try
            {
                var getPayments = await _mediator.Send(getPaymentsRequest);

                if (getPayments is null)
                {
                    return StatusCode(
                        statusCode: (int)HttpStatusCode.NotFound,
                        value: new ErrorDto("Payments Not Found."));
                }

                var paymentsResponse = getPayments.Payments.Select(p =>
                    new GetPaymentsDto(
                        transactionId: p.TransactionId,
                        cardHolderName: p.CardHolderName,
                        ammount: p.Ammount,
                        isApproved: p.IsApproved,
                        transactionDate: p.TransactionDate));

                return Ok(new GetPaymentsResponseDto(paymentsResponse));
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    value: new ErrorDto(ex.Message));
            }
        }

        [HttpGet("GetPaymentsByCustomerAndDate")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(GetPaymentsResponseDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetPaymentsByCustomerAndDateAsync([FromQuery] Guid clientId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var getPaymentsRequest = new GetPaymentsByCustomerAndDateQueryRequest(
                clientId: clientId,
                startDate: startDate,
                endDate: endDate);

            try
            {
                var getPayments = await _mediator.Send(getPaymentsRequest);

                if (getPayments is null)
                {
                    return StatusCode(
                        statusCode: (int)HttpStatusCode.NotFound,
                        value: new ErrorDto("Payments Not Found."));
                }

                var paymentsResponse = getPayments.Payments.Select(p =>
                    new GetPaymentsDto(
                        transactionId: p.TransactionId,
                        cardHolderName: p.CardHolderName,
                        ammount: p.Ammount,
                        isApproved: p.IsApproved,
                        transactionDate: p.TransactionDate));

                return Ok(new GetPaymentsResponseDto(paymentsResponse));
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    value: new ErrorDto(ex.Message));
            }
        }
    }
}