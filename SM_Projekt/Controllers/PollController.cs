using Application.DTOs.Poll;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SM_Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IPollService _pollService;

        public PollController(IPollService pollService)
        {
            _pollService = pollService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> GetAll()
        {
            return Ok(await _pollService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> Get(int id)
        {
            bool isAnonymous = HttpContext.User?.Identity?.Name is null;
            return Ok(await _pollService.Get(id,isAnonymous));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> Put(int id, PollCreateDTO poll)
        {
            return Ok(await _pollService.Update(poll,id));
        }

        [HttpPut("activate/{id}")]
        public async Task<ActionResult> Activate(int id)
        {
            await _pollService.Activate(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _pollService.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PollCreateDTO pollCreateDTO)
        {
            var identity = (ClaimsIdentity?)HttpContext.User.Identity;
            string? userId = null;
            if (identity is not null && identity.IsAuthenticated)
            {
                userId = identity.Claims?.FirstOrDefault(
                    x => x.Type.Contains("nameidentifier")
                    ).Value;
            }
            int id = await _pollService.Create(pollCreateDTO, userId);
            PollBaseDTO poll = await _pollService.Get(id, false);
            return CreatedAtAction(nameof(UserController.Get), new { id = id }, poll);
        }

    }

}
