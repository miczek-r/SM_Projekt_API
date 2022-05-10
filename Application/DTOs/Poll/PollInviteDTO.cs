using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Poll
{
    public class PollInviteDTO
    {
        [SwaggerSchema("The list of vote users ids")]
        public virtual ICollection<string>? UserIds { get; set; }
    }
}
