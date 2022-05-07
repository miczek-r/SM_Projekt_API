using Application.DTO.User;
using Application.DTOs.Question;
using Core.Entities;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Poll
{
    public class PollInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CreatedBy { get; set; }
        public bool AllowAnonymous { get; set; }
        public bool IsActive { get; set; }
        public bool ResultsArePublic { get; set; }
        public PollType PollType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<UserBaseDTO>? AllowedUsers { get; set; }
        public virtual ICollection<UserBaseDTO>? Moderators { get; set; }
        public virtual ICollection<string>? VotingTokens { get; set; }
        public virtual ICollection<QuestionBaseDTO>? Questions { get; set; }
    }
}

