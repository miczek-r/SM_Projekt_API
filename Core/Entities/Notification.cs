﻿using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Notification: BaseEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool Seen { get; set; }
    }
}