using Application.DTOs.Vote;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SM_Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : Controller
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpGet("{pollId}")]
        public async Task<ActionResult<VoteInfoDTO>> Get(int pollId)
        {
            return Ok(await _voteService.Get(pollId));
        }

        [HttpPost]
        public async Task<ActionResult> Vote(VoteCreateDTO voteBaseDTO)
        {
            await _voteService.VoteSingle(voteBaseDTO);
            return Ok();
        }

        [HttpPost("Aggregate")]
        public async Task<ActionResult> VoteAggregate(VoteAggregateDTO voteAggregateDTO)
        {
            await _voteService.VoteAggregate(voteAggregateDTO);
            return Ok();
        }
    }
}
