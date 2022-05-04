using Application.DTOs.Question;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Poll
{
    public class PollCreateDTO
    {
        public string Name { get; set; }
        public bool AllowAnonymous { get; set; }
        public bool ResultsArePublic { get; set; }
        public PollType PollType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<QuestionCreateDTO>? Questions { get; set; }
        public virtual ICollection<string>? AllowedUsersIds { get; set; }
        public virtual ICollection<string>? ModeratorsIds { get; set; }
    }
}
