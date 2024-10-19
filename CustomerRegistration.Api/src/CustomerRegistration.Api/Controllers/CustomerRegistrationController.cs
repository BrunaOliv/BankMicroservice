using CustomerRegistration.Application.Commands.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerRegistration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerRegistrationController(IMediator mediator)
        {
               _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Cliente criado com sucesso.");
        }
    }
}
