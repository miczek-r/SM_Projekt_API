using Application.DTOs.Poll;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PollService : IPollService
    {
        private readonly IPollRepository _pollService;
        private readonly IMapper _mapper;

        public PollService(IPollRepository pollService, IMapper mapper)
        {
            _pollService = pollService;
            _mapper = mapper;
        }

        public async Task Activate(int id)
        {
            Poll poll = await _pollService.GetByIdAsync(id);
            if(poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if(poll.ExpirationDate<= DateTime.Now)
            {
                throw new ObjectValidationException("This poll cannot be activated because expiration date must be future");
            }
            poll.IsActive = true;
            await _pollService.UpdateAsync(poll);

        }

        public async Task<int> Create(PollCreateDTO pollCreateDTO)
        {
            Poll newPoll = _mapper.Map<Poll>(pollCreateDTO);
            await _pollService.AddAsync(newPoll);
            return newPoll.Id;
        }

        public async Task Delete(int id)
        {
            Poll pollToDelete = await _pollService.GetByIdAsync(id);
            if(pollToDelete is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            await _pollService.DeleteAsync(pollToDelete);
        }

        public async Task<PollBaseDTO> Get(int id, bool isAnonymous)
        {   
            Poll poll = await _pollService.GetBySpecAsync(new PollSpecification(x=>x.Id == id));
            if(poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if(isAnonymous && !poll.AllowAnonymous)
            {
                throw new AccessForbiddenException("You are not allowed to join this poll");
            }
            PollBaseDTO result = _mapper.Map<PollBaseDTO>(poll);
            return result;
        }

        public async Task<IEnumerable<PollLiteDTO>> GetAll()
        {
            IEnumerable<Poll> poll = await _pollService.GetAllAsync();
            IEnumerable<PollLiteDTO> result = _mapper.Map<IEnumerable<PollLiteDTO>>(poll);
            return result;
        }

        public async Task<PollLiteDTO> Update(PollCreateDTO pollCreateDTO, int id)
        {
            Poll poll = await _pollService.GetByIdAsync(id);
            if (poll is null)
            {
                throw new ObjectNotFoundException();
            }
            poll.AllowAnonymous = pollCreateDTO.AllowAnonymous;
            poll.IsActive = pollCreateDTO.IsActive;
            poll.ExpirationDate = pollCreateDTO.ExpirationDate;
            poll.Questions = _mapper.Map<List<Question>>(pollCreateDTO.Questions);
            await _pollService.UpdateAsync(poll);
            var result = _mapper.Map<PollLiteDTO>(poll);
            return result;
        }
    }
}
