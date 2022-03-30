using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TokenInfoDTO
    {
        public string? Token { get; set; }
        public DateTime TokenValidUntil { get; set; }
    }
}
