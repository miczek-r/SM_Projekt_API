using Application.DTOs.Answer;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class AnswerMappingProfile:Profile
    {
        public AnswerMappingProfile()
        {
            CreateMap<AnswerCreateDTO, Answer>().PreserveReferences();
            CreateMap<Answer, AnswerBaseDTO>().PreserveReferences();
        }
    }
}
 