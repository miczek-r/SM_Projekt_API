using Application.DTOs.Vote;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace SM_Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class VoteController : Controller
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpGet("{pollId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(VoteInfoDTO))]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VoteInfoDTO>> Get(int pollId)
        {
            return Ok(await _voteService.Get(pollId));
        }

        [HttpPost("Aggregate")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> VoteAggregate(VoteAggregateDTO voteAggregateDTO)
        {
            await _voteService.VoteAggregate(voteAggregateDTO);
            return NoContent();
        }
    }
}
