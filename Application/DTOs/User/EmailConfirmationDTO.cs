﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class EmailConfirmationDTO
    {
        public string? UserId { get; set; }
        public string? ConfirmationToken { get; set; }
    }
}
