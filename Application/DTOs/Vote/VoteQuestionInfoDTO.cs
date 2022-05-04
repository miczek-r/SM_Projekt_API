﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Vote
{
    public class VoteQuestionInfoDTO
    {
        public int QuestionId { get; set; }
        public ICollection<VoteAnswerInfoDTO>? Answers { get; set; }
    }
}