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
        Task VoteSingle(VoteCreateDTO vote);
        Task VoteAggregate(VoteAggregateDTO votes);
        Task<VoteInfoDTO> Get(int pollId);
    }
}
