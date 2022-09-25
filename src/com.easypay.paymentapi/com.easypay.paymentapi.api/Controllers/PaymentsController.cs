using com.easypay.paymentapi.api.Controllers.Dtos;
using com.easypay.paymentapi.api.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using com.easypay.paymentapi.application.Payments.Queries;

namespace com.easypay.paymentapi.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;

        private readonly IMediator _mediator;

        public PaymentsController(
            ILogger<PaymentsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("Get")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(GetPaymentsDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetpaymentsAsync(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var getClientQueryRequest = new GetPaymentsQueryRequest(startDate, endDate);

            try
            {
                var getPayments = await _mediator.Send(getClientQueryRequest);

                if (getPayments is null)
                {
                    var error = new ErrorDto("No Payments Found.");
                    return NotFound(error);
                }

                var response = new GetPaymentsDto(
                    getPayments.Payments.Select(p=> new PaymentsDto(
                        transactionId: p.TransactionId,
                        cardHolderName: p.CardHolderName,
                        transactionDate: p.TransactionDate,
                        isApproved: p.IsApproved,
                        ammount: p.Ammount)));

                return Ok(response);
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