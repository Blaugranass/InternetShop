using InternetShop.Application.Queries.Carts;
using InternetShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartsController(IMediator mediator) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<ActionResult> AddItem()
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Cart>> GetCart()
        {
            if(User.Identity?.IsAuthenticated == true)
            {
                var claim = User.FindFirst("clientId");

                var cart = await mediator.Send(new GetCartQuery(Guid.Parse(claim!.Value)));
                return Ok(cart);
            }
            else
            {
                var cart = await mediator.Send(new GetCartCookiesQuery());
                return Ok(cart);
            }
        }
    }
}
