using Application.DTOs.Notification;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<NotificationBaseDTO>>> GetAll()
        {
            return Ok(await _notificationService.GetAll());
        }

        [HttpGet("{notificationId}")]
        public async Task<ActionResult<IEnumerable<NotificationBaseDTO>>> Get(int notificationId)
        {
            return Ok(await _notificationService.Get(notificationId));
        }
        [HttpPut("SetAsSeen/{notificationId}")]
        public async Task<ActionResult> SetAsSeen(int notificationId)
        {
            await _notificationService.SetAsSeen(notificationId);
            return Ok();
        }
        [HttpDelete("{notificationId}")]
        public async Task<ActionResult> Delete(int notificationId)
        {
            await _notificationService.Delete(notificationId);
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] NotificationCreateDTO notificationCreateDTO)
        {
            int id = await _notificationService.Create(notificationCreateDTO);
            return Ok(id);
        }

    }
}
