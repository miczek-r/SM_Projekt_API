﻿using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Notification
{
    public class NotificationLiteDTO
    {
        [SwaggerSchema("The notification identifier")]
        public int Id { get; set; }
        [SwaggerSchema("The notification title", Nullable = false)]
        public string Title { get; set; } = string.Empty;
        [SwaggerSchema("The boolean determining if the notification was seen when true")]
        public bool Seen { get; set; }
    }
}
