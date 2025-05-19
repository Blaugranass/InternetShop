using InternetShop.Application.Queries.Announcements;
using InternetShop.Application.Commands.Announcements;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Application.Dtos.Announcements;
using InternetShop.Application.Handlers.Announcements;
using InternetShop.Application.Pagination;
using InternetShop.Domain.Filters;

namespace InternetShop.API.Controllers
{
    [Route("api/announcements")]
    [ApiController]
    public class AnnouncementsController(IMediator mediator) : ControllerBase
    {

        [HttpGet("all")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult<IEnumerable<Announcement>>> GetAllAnnouncement()
        {
            var announcements = await mediator.Send(new GetActiveAnnouncementsQuery());
            return Ok(announcements);
        }

        [HttpGet]
        [Authorize(Roles = "Operator, Client")]
        public async Task<ActionResult<PagedResult<Announcement>>> GetAnnouncementsAsync(
            [FromQuery] PageParams pageParams,
            [AsParameters, FromQuery] AnnouncementFilters filters,
            CancellationToken cancellationToken)
        {
            var announcements = await mediator.Send(
                new GetAnnouncementsQuery(pageParams, filters),
                cancellationToken);

            return Ok(announcements);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Operator, Client")]
        public async Task<ActionResult<Announcement>> GetAnnouncementById(Guid id)
        {
            var announcement = await mediator.Send(
                new GetAnnouncementByIdQuery(id));

            return Ok(announcement);
        }
        
        [HttpPost("create/accessory")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult<Guid>> CreateAnnouncement(
            [FromBody] CreateAnnouncementAccessoryDto create,
            CancellationToken cancellationToken)
        {
            var id = await mediator.Send(new CreateAnnouncementAccessoryCommand(create), cancellationToken);
            return Ok(id);
        }

        [HttpPost("create/computer-hardware")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult<Guid>> CreateAnnouncement(
            [FromBody] CreateAnnouncementComputerHardwareDto create,
            CancellationToken cancellationToken)
        {
            var id = await mediator.Send(new CreateAnnouncementComputerHardwareCommand(create), cancellationToken);
            return Ok(id);
        }

        [HttpPatch("edit/{id}")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult> EditAnnouncement(
            Guid id,
            [FromBody] EditAnnouncementDto dto,
            CancellationToken cancellationToken)
        {
            await mediator.Send(new EditAnnouncementCommand(id,dto), cancellationToken);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult> DeleteAnnouncement(Guid id, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteAnnouncementCommand(id), cancellationToken);
            return Ok();
        }

    }
}