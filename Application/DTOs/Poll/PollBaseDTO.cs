using Application.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Poll
{
    public class PollBaseDTO
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public bool AllowAnonymous { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
        public virtual ICollection<QuestionBaseDTO>? Questions { get; set; }
    }
}
