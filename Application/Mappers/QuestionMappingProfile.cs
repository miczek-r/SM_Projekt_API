using Application.DTOs.Answer;
using Application.DTOs.Question;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<QuestionCreateDTO, Question>().PreserveReferences();
            CreateMap<Question, QuestionBaseDTO>()
                
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src =>
                src.Type == QuestionType.Open ? null : src.Answers
                ))
                .PreserveReferences();
        }
    }
}
