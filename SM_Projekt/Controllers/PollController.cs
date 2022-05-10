using Application.DTOs.Poll;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace SM_Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class PollController : ControllerBase
    {
        private readonly IPollService _pollService;

        public PollController(IPollService pollService)
        {
            _pollService = pollService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<PollBaseDTO>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> GetAll()
        {
            return Ok(await _pollService.GetAll());
        }

        [HttpGet("{pollId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PollBaseDTO))]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PollBaseDTO>> Get(int pollId)
        {
            return Ok(await _pollService.Get(pollId));
        }

        [HttpGet("GetInfo/{pollId}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PollBaseDTO))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PollBaseDTO>> GetInfo(int pollId)
        {
            return Ok(await _pollService.GetInfo(pollId));
        }

        [HttpGet("MyPolls")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<PollBaseDTO>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> GetMyPolls()
        {
            return Ok(await _pollService.GetMyPolls());
        }

        /*[HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> Put(int id, PollCreateDTO poll)
        {
            return Ok(await _pollService.Update(poll,id));
        }*/

        [HttpPut("Activate/{pollId}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Activate(int pollId)
        {
            await _pollService.OpenPoll(pollId);
            return NoContent();
        }

        [HttpPut("Invite/{pollId}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InviteToPoll(int pollId, PollInviteDTO pollInviteDTO)
        {
            await _pollService.InviteUsers(pollId, pollInviteDTO);
            return NoContent();
        }

        [HttpPut("SetModerators/{pollId}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SetPollModerators(int pollId, PollInviteDTO pollInviteDTO)
        {
            await _pollService.SetPollModerators(pollId, pollInviteDTO);
            return NoContent();
        }

        [HttpDelete("{pollId}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int pollId)
        {
            await _pollService.ClosePoll(pollId);
            return NoContent();
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] PollCreateDTO pollCreateDTO)
        {
            
            int id = await _pollService.Create(pollCreateDTO);
            PollBaseDTO poll = await _pollService.Get(id);
            return CreatedAtAction(nameof(PollController.Post), new { id }, poll);
        }

    }

}
