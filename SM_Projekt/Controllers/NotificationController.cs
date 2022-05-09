using Application.DTOs.Notification;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SM_Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<NotificationBaseDTO>))]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<NotificationBaseDTO>>> GetAll()
        {
            return Ok(await _notificationService.GetAll());
        }

        [HttpGet("{notificationId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(NotificationBaseDTO))]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NotificationBaseDTO>> Get(int notificationId)
        {
            return Ok(await _notificationService.Get(notificationId));
        }

        [HttpPut("SetAsSeen/{notificationId}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> SetAsSeen(int notificationId)
        {
            await _notificationService.SetAsSeen(notificationId);
            return NoContent();
        }
        [HttpDelete("{notificationId}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int notificationId)
        {
            await _notificationService.Delete(notificationId);
            return NoContent();
        }

        private async Task GetPrivate(int notificationId)
        {
            await _notificationService.Get(notificationId);
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] NotificationCreateDTO notificationCreateDTO)
        {
            int id = await _notificationService.Create(notificationCreateDTO);
            NotificationBaseDTO notification = await _notificationService.GetPrivate(id);
            return CreatedAtAction(nameof(NotificationController.Post), new { id }, notification);
        }

    }
}
