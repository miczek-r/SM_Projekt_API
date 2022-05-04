using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Poll
{
    public class PollLiteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CreatedBy { get; set; }
        public bool AllowAnonymous { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
