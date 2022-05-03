using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class VotingToken
    {
        public int PollId { get; set; }
        [Key]
        public string Token { get; set; }
    }
}
