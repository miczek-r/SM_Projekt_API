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
            CreateMap<Vote, VoteBaseDTO>().PreserveReferences();
            CreateMap<VoteCreateDTO, Vote>().PreserveReferences();
        }
    }
}
