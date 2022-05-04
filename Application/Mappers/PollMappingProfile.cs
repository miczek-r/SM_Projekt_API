﻿using Application.DTOs.Poll;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class PollMappingProfile:Profile
    {
        public PollMappingProfile()
        {
            CreateMap<PollCreateDTO, Poll>()
                .ForMember(dest => dest.AllowedUsers,
                opt => opt.MapFrom(
                    source=> source.AllowedUsersIds.Select(id => new PollAllowed { UserId = id})))
                .PreserveReferences();
            CreateMap<Poll, PollBaseDTO>().PreserveReferences();
            CreateMap<Poll, PollLiteDTO>().PreserveReferences();
        }
    }
}
