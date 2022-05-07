using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Poll
{
    public class PollInviteDTO
    {
        public virtual ICollection<string>? UserIds { get; set; }
    }
}
