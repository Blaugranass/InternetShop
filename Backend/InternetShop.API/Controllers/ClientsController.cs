using InternetShop.Application.Commands.Clients;
using InternetShop.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.API.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController(IMediator mediator) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult> RegisterClient(RegisterClientDto registerClientDto)
        {
            await mediator.Send(new RegisterClientCommand(registerClientDto));
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginClient(LoginClientDto loginClientDto)
        {
            await mediator.Send(new LoginClientCommand(loginClientDto));
            return Ok();
        }

    }
}
