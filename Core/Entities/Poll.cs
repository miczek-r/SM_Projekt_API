using Core.Entities.Base;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Poll: BaseEntity
    {
        public string Name { get; set; }
        public string? CreatedBy { get; set; }
        public bool AllowAnonymous { get; set; }
        public bool IsActive { get; set; }
        public bool ResultsArePublic { get; set; }
        public PollType PollType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual ICollection<PollAllowed>? AllowedUsers { get; set; }
        public virtual ICollection<PollModerators>? Moderators { get; set; }
        public virtual ICollection<Question>? Questions { get; set; }
        public virtual ICollection<VotingToken>? VotingTokens { get; set; }
        
    }
}
