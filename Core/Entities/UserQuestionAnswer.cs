﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserQuestionAnswer
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        public User User { get; set; }
        [Key, Column(Order = 1)]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        [Key, Column(Order = 2)]
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
