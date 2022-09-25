using com.easypay.be.api.Controllers.Client.Dtos;
using com.easypay.be.api.Controllers.Payment.Dtos;
using com.easypay.be.api.Dtos;
using com.easypay.be.application.Clients.Commands;
using com.easypay.be.application.Clients.Queries;
using com.easypay.be.application.Payments.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace com.easypay.be.api.Controllers.Client
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        private readonly IMediator _mediator;

        public ClientController(
            ILogger<ClientController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("Create")]
        [Consumes("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.Created, type: typeof(CreateClientResponseDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateClientAsync([FromBody] CreateClientRequestDto request)
        {
            var createClientCommandRequest = new CreateClientCommandRequest(
                name: request.Name,
                agency: request.Agency,
                account: request.Account,
                bank: request.Bank);

            try
            {
                var createdClient = await _mediator.Send(createClientCommandRequest);

                var response = new CreateClientResponseDto(createdClient.Id);

                return StatusCode(
                    statusCode: (int)HttpStatusCode.Created,
                    value: response);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    value: new ErrorDto(ex.Message));
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ClientResponseDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateClientAsync(
            [FromQuery] Guid clientId,
            [FromBody] CreateClientRequestDto request)
        {
            var updateClientCommandRequest = new UpdateClientCommandRequest(
                id: clientId,
                name: request.Name,
                agency: request.Agency,
                account: request.Account,
                bank: request.Bank);

            try
            {
                var updatedClient = await _mediator.Send(updateClientCommandRequest);

                var response = new ClientResponseDto(
                    id: updatedClient.Id,
                    agency: updatedClient.Agency,
                    account: updatedClient.Account,
                    bank: updatedClient.Bank);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    value: new ErrorDto(ex.Message));
            }
        }

        [HttpGet("Get")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ClientResponseDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetClientAsync([FromQuery] Guid clientId)
        {
            var getClientQueryRequest = new GetClientQueryRequest(clientId);

            try
            {
                var getClient = await _mediator.Send(getClientQueryRequest);
                if (getClient is null)
                {
                    var error = new ErrorDto("No Client Found.");
                    return NotFound(error);
                }

                var response = new ClientResponseDto(
                    id: getClient.Id,
                    agency: getClient.Agency,
                    account: getClient.Account,
                    bank: getClient.Bank);

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