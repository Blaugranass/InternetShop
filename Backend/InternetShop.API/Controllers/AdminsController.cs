using InternetShop.Application.Commands.Administrators;
using InternetShop.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace InternetShop.API.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminsController(IMediator mediator) : ControllerBase
    {
        public async Task<ActionResult> RegisterAdmin(RegisterAdminDto registerAdminDto)
        {  
            try
            { 
                await mediator.Send(new RegisterAdministratorCommand(registerAdminDto));
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> LoginAdmin(LoginAdminDto loginAdminDto)
        {
            try
            {
                await mediator.Send(new LoginAdministratorCommand(loginAdminDto));
                return Ok();            
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
