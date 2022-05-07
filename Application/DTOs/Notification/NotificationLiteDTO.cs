using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Notification
{
    public class NotificationLiteDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Seen { get; set; }
    }
}
