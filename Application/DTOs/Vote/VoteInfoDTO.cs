using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Vote
{
    public class VoteInfoDTO
    {
        [SwaggerSchema("The list of list of all submitted votes summary for selected poll")]
        public ICollection<VoteSummaryDTO>? VoteQuestions { get; set; }
        [SwaggerSchema("The list of list of all submitted votes for selected poll")]
        public ICollection<VoteBaseDTO>? BaseAnswers { get; set; }
    }
}
