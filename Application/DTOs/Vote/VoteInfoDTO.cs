using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Vote
{
    public class VoteInfoDTO
    {
        public ICollection<VoteQuestionInfoDTO>? VoteQuestions { get; set; }
        public ICollection<VoteBaseDTO>? BaseAnswers { get; set; }
    }
}
