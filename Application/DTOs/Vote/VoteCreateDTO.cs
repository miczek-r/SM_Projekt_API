using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Vote
{
    public class VoteCreateDTO
    {
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public string? AnswerText { get; set; }
    }
}
