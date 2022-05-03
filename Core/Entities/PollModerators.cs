using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PollModerators
    {
        [Key, Column(Order = 1)]
        public int PollId { get; set; }
        public Poll Poll { get; set; }
        [Key, Column(Order = 2)]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
