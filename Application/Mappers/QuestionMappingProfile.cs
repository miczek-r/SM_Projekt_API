using Application.DTOs.Question;
using AutoMapper;
using Core.Entities;
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
            CreateMap<Question, QuestionBaseDTO>().PreserveReferences();
        }
    }
}
