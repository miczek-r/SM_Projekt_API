using Application.DTOs.Vote;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class VoteMappingProfile : Profile
    {
        public VoteMappingProfile()
        {
            CreateMap<Vote, VoteBaseDTO>().PreserveReferences()
                .ForMember(dest => dest.Question, opt =>
                    opt.MapFrom(src => src.Question.Text))
                .ForMember(dest => dest.Answer, opt =>
                    opt.MapFrom(src => src.Answer.Text));
            CreateMap<VoteCreateDTO, Vote>().PreserveReferences()
                .ForMember(dest => dest.Answer, opt =>
                 {
                     opt.PreCondition(src => src.AnswerText is not null);
                     opt.MapFrom(src => new Answer() { Text = src.AnswerText, QuestionId = src.QuestionId });
                 });
        }
    }
}
