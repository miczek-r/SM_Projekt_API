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
        public string? CreatedBy { get; set; }
        public bool AllowAnonymous { get; set; }
        public bool IsActive { get; set; }
        public PollType PollType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public virtual ICollection<User>? AllowedUsers { get; set; }
        public virtual ICollection<Question>? Questions { get; set; }
        
    }
}
