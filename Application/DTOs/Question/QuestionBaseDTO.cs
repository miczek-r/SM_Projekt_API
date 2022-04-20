using Application.DTOs.Answer;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Question
{
    public class QuestionBaseDTO
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? Description { get; set; }
        public QuestionType Type { get; set; }
        public virtual ICollection<AnswerBaseDTO>? Answers { get; set; }
    }
}
