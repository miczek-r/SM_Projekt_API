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
        private readonly IPollRepository _pollRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMailService _mailService;

        public PollService(IPollRepository pollRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IMailService mailservice)
        {
            _pollRepository = pollRepository;
            _mapper = mapper;
            _contextAccessor = httpContextAccessor;
            _mailService = mailservice;
        }

        public async Task Activate(int pollId)
        {
            string? userId = GetCurrentUserId();
            Poll poll = await _pollRepository.GetBySpecAsync(new PollSpecification(x => x.Id == pollId));
            if(poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if (userId is null || (poll.CreatedBy != userId || poll.CreatedBy is null) && poll.Moderators.Any(x => x.UserId == userId))
            {
                throw new AccessForbiddenException("You dont have permissions to activate this poll");
            }
            if (poll.ExpirationDate<= DateTime.Now)
            {
                throw new ObjectValidationException("This poll cannot be activated because expiration date must be future");
            }
            poll.IsActive = true;
            await _pollRepository.UpdateAsync(poll);
            if(poll.PollType == Core.Enums.PollType.Protected)
            {
                if(poll.VotingTokens is null)
                {
                    poll.VotingTokens = new List<VotingToken>();
                }
                foreach(PollAllowed user in poll.AllowedUsers)
                {
                    string token = Guid.NewGuid().ToString();
                    poll.VotingTokens.Add(new VotingToken { PollId = poll.Id, Token = token });
                    await _mailService.SendEmailAsync(user.User.Email, "Poll has started", $"Your voting token: {token}");
                }
            }

        }

        public async Task Close(int pollId)
        {
            string? userId = GetCurrentUserId();
            Poll poll = await _pollRepository.GetByIdAsync(pollId);
            if (poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if (userId is null || (poll.CreatedBy != userId || poll.CreatedBy is null) && poll.Moderators.Any(x => x.UserId == userId))
            {
                throw new AccessForbiddenException("You dont have permissions to activate this poll");
            }
            poll.IsActive = false;
            poll.VotingTokens = null;
            await _pollRepository.UpdateAsync(poll);
        }

        public async Task<int> Create(PollCreateDTO pollCreateDTO)
        {
            string? userId = GetCurrentUserId();
            Poll newPoll = _mapper.Map<Poll>(pollCreateDTO);
            newPoll.CreatedBy = userId;
            await _pollRepository.AddAsync(newPoll);
            return newPoll.Id;
        }

        public async Task Delete(int id)
        {
            string? userId = GetCurrentUserId();
            Poll pollToDelete = await _pollRepository.GetByIdAsync(id);
            if(pollToDelete is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if(pollToDelete.CreatedBy != userId || pollToDelete.CreatedBy is null)
            {
                throw new AccessForbiddenException("You dont have permissions to delete this poll");
            }
            await _pollRepository.DeleteAsync(pollToDelete);
        }

        public async Task<PollBaseDTO> Get(int id)
        {
            bool isAnonymous = GetCurrentUserId() is null;
            Poll poll = await _pollRepository.GetBySpecAsync(new PollSpecification(x=>x.Id == id));
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
            IEnumerable<Poll> poll = await _pollRepository.GetAllAsync();
            poll = poll.Where(x => x.PollType == Core.Enums.PollType.Public);
            IEnumerable<PollLiteDTO> result = _mapper.Map<IEnumerable<PollLiteDTO>>(poll);
            return result;
        }

        public async Task<PollLiteDTO> Update(PollCreateDTO pollCreateDTO, int id)
        {
            string? userId = GetCurrentUserId();
            Poll poll = await _pollRepository.GetByIdAsync(id);
            if (poll is null)
            {
                throw new ObjectNotFoundException();
            }
            if (userId is null || (poll.CreatedBy != userId || poll.CreatedBy is null) && poll.Moderators.Any(x=>x.UserId == userId))
            {
                throw new AccessForbiddenException("You dont have permissions to modify this poll");
            }
            poll.AllowAnonymous = pollCreateDTO.AllowAnonymous;
            poll.IsActive = pollCreateDTO.IsActive;
            poll.ExpirationDate = pollCreateDTO.ExpirationDate;
            poll.Questions = _mapper.Map<List<Question>>(pollCreateDTO.Questions);
            await _pollRepository.UpdateAsync(poll);
            var result = _mapper.Map<PollLiteDTO>(poll);
            return result;
        }

        private string? GetCurrentUserId()
        {
            var identity = (ClaimsIdentity?)_contextAccessor.HttpContext?.User.Identity;
            string? userId = null;
            if (identity is not null && identity.IsAuthenticated)
            {
                userId = identity.Claims?.FirstOrDefault(
                    x => x.Type.Contains("nameidentifier")
                    )?.Value;
            }
            return userId;
        }
    }
}
