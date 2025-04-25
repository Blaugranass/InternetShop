using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        [HttpPost("item")]
        public async Task<ActionResult> AddItem()
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
