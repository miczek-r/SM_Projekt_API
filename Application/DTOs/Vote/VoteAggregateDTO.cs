using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Vote
{
    public class VoteAggregateDTO
    {
        public ICollection<VoteCreateDTO>? Votes { get; set; }
    }
}
