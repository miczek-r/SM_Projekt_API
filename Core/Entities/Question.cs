using Core.Entities.Base;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Question : BaseEntity
    {
        public string? Text { get; set; } 
        public string? Description { get; set; }
        public QuestionType Type { get; set; }
        public virtual ICollection<Answer>? Answers { get; set; }
    }
}
