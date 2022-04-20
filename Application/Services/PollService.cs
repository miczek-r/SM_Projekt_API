using Application.DTOs.Poll;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
                throw new ObjectNotFoundException();
            }
            if(poll.ExpirationDate<= DateTime.Now)
            {
                throw new ObjectValidationException();
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
                throw new ObjectNotFoundException();
            }
            await _pollService.DeleteAsync(pollToDelete);
        }

        public async Task<PollBaseDTO> Get(int id)
        {   
            Poll poll = await _pollService.GetByIdAsync(id);
            if(poll is null)
            {
                throw new ObjectNotFoundException();
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

        public async Task<PollLiteDTO> Update(PollCreateDTO pollCreateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
