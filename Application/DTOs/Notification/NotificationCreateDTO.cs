using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Notification
{
    public class NotificationCreateDTO
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
