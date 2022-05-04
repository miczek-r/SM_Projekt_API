using Application.DTOs.Answer;
using Core.Enums;

namespace Application.DTOs.Question
{
    public class QuestionCreateDTO
    {
        public string? Text { get; set; }
        public string? Description { get; set; }
        public QuestionType Type { get; set; }
        public virtual ICollection<AnswerCreateDTO>? Answers { get; set; }
    }
}