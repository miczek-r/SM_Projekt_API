using Application.DTOs.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVoteService
    {
        Task Vote(VoteCreateDTO vote, string userId);
        Task VoteAggregate(VoteAggregateDTO votes, string userId);
        Task<VoteInfoDTO> Get(int pollId, string userId);
    }
}
