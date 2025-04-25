using InternetShop.Application.Quaries;
using InternetShop.Application.Commands.Announcements;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Application.Dtos;

namespace InternetShop.API.Controllers
{
    [Route("api/announcements")]
    [ApiController]
    public class AnnouncementsController(IMediator mediator) : ControllerBase
    {
        private static List<Announcement> announcements = new List<Announcement>
        {
            new() {
                Id = Guid.NewGuid(),
                Status = AnnouncementStatus.Active,
                Product = new Accessory 
                {
                    Id = Guid.NewGuid(),
                    Name = "Чехол Красивый",
                    Description = "Чехол для iPhone 15",
                    AccessoryTypeId = Guid.Parse("d3d3d3d3-d3d3-d3d3-d3d3-d3d3d3d3d3d3"),
                    Type = new AccessoryType 
                    { 
                        Id = Guid.Parse("d3d3d3d3-d3d3-d3d3-d3d3-d3d3d3d3d3d3"),
                        Type = "Чехлы" 
                    }
                },
                Quantity = 10,
                Price = 29.99m,
                CreatedAt = DateTime.UtcNow
            },
            new() {
                Id = Guid.NewGuid(),
                Status = AnnouncementStatus.Frozen,
                Product = new Accessory 
                {
                    Id = Guid.NewGuid(),
                    Name = "Наушники лучшие",
                    Description = "Беспроводные наушники",
                    AccessoryTypeId = Guid.Parse("c4c4c4c4-c4c4-c4c4-c4c4-c4c4c4c4c4c4"),
                    Type = new AccessoryType 
                    { 
                        Id = Guid.Parse("c4c4c4c4-c4c4-c4c4-c4c4-c4c4c4c4c4c4"),
                        Type = "Аксессуары для аудио" 
                    }
                },
                Quantity = 5,
                Price = 149.99m,
                CreatedAt = DateTime.UtcNow
            }
        };
                
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Announcement>>> GetAllAnnouncement()
        {
            try
            {
            await Task.Delay(0); 
            return Ok(announcements);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult<Announcement>> GetAnnouncementById(Guid id)
        {
            try
            {
                var announcement = await mediator.Send(new GetAnnouncementByIdQuery(id));
                return Ok(announcement);
            }
            catch(NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("create/accessory")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult<Guid>> CreateAnnouncement([FromBody] CreateAnnouncementAccessoryDto create)
        {
            try
            {
                var id = await mediator.Send(new CreateAnnouncementAccessoryCommand(create));
                return Ok(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("edit/{id}")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult> EditAnnoucement(Guid id, [FromBody] EditAnnouncementDto dto)
        {
            try
            {
                await mediator.Send(new EditAnnouncementCommand(id,dto));
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult> DeleteAnnouncement(Guid id)
        {
            try
            {
                await mediator.Send(new DeleteAnnouncementCommand(id));
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}