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
            string? userId = GetUserInfo();
            return Ok(await _voteService.Get(pollId, userId));
        }

        [HttpPost]
        public async Task<ActionResult> Vote(VoteCreateDTO voteBaseDTO)
        {
            string? userId = GetUserInfo();
            await _voteService.VoteSingle(voteBaseDTO, userId);
            return Ok();
        }

        [HttpPost("Aggregate")]
        public async Task<ActionResult> VoteAggregate(VoteAggregateDTO voteAggregateDTO)
        {
            string? userId = GetUserInfo();
            await _voteService.VoteAggregate(voteAggregateDTO, userId);
            return Ok();
        }
        private string? GetUserInfo()
        {
            var identity = (ClaimsIdentity?)HttpContext.User.Identity;
            string? userId = null;
            if (identity is not null && identity.IsAuthenticated)
            {
                userId = identity.Claims?.FirstOrDefault(
                    x => x.Type.Contains("nameidentifier")
                    ).Value;
            }

            return userId;
        }
    }
}
