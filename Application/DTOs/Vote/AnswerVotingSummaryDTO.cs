using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Vote
{
    public class AnswerVotingSummaryDTO
    {
        [SwaggerSchema("The answer identificator")]
        public int AnswerId { get; set; }
        [SwaggerSchema("The answer text", Nullable = false)]
        public string AnswerText { get; set; } = string.Empty;
        [SwaggerSchema("The number of votes submitted for a given answer")]
        public int Count { get; set; }
    }
}
