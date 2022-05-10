using Application.DTOs.Notification;
using Application.DTOs.Poll;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Repositories;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMailService _mailService;
        private readonly UserManager<User> _userManager;

        public PollService(IPollRepository pollRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IMailService mailservice, UserManager<User> userManager, INotificationService notificationService)
        {
            _pollRepository = pollRepository;
            _mapper = mapper;
            _contextAccessor = httpContextAccessor;
            _mailService = mailservice;
            _userManager = userManager;
            _notificationService = notificationService;
        }

        public async Task OpenPoll(int pollId)
        {
            string? userId = GetCurrentUserId();
            Poll poll = await _pollRepository.GetBySpecAsync(new PollSpecification(x => x.Id == pollId));
            if (poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if (poll.CreatedBy is not null && (userId is null || (poll.CreatedBy != userId && poll.Moderators.Any(x => x.UserId == userId))))
            {
                throw new AccessForbiddenException("You do not have permissions to activate this poll");
            }
            if (poll.IsActive == true)
            {
                throw new ObjectValidationException("This poll is already open");
            }
            poll.IsActive = true;
            await _pollRepository.UpdateAsync(poll);


            if (poll.VotingTokens is null)
            {
                poll.VotingTokens = new List<VotingToken>();
            }
            foreach (PollAllowed user in poll.AllowedUsers)
            {
                await _notificationService.Create(new NotificationCreateDTO() { Title = $"Poll '{poll.Name}' has started", Message = $"The poll: '{poll.Name}' has started.", UserId = user.UserId });
                if (poll.PollType == Core.Enums.PollType.Protected)
                {
                    await SendVotingToken(poll, user.User);
                }
            }

        }

        private async Task SendVotingToken(Poll poll, User user)
        {
            string token = Guid.NewGuid().ToString();
            poll.VotingTokens.Add(new VotingToken { PollId = poll.Id, Token = token });
            var replacementData = new Dictionary<string, object>
                {
                    {
                        "PollName", poll.Name
                    },
                    {
                        "PollDescription", $"Voting token: {token}"
                    }
                };
            await _mailService.SendEmailAsync(user.Email, $"Poll '{poll.Name}' has started", "pollStarted", replacementData);
        }

        public async Task ClosePoll(int pollId)
        {
            string? userId = GetCurrentUserId();
            Poll poll = await _pollRepository.GetBySpecAsync(new PollSpecification(x => x.Id == pollId));
            if (poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if (userId is null || (poll.CreatedBy != userId || poll.CreatedBy is null) && poll.Moderators.Any(x => x.UserId == userId))
            {
                throw new AccessForbiddenException("You do not have permissions to activate this poll");
            }
            poll.IsActive = false;
            poll.VotingTokens = null;
            foreach (PollAllowed user in poll.AllowedUsers)
            {
                await _notificationService.Create(new NotificationCreateDTO() { Title = $"Poll '{poll.Name}' has ended", Message = $"The poll: '{poll.Name}' has ended.", UserId = user.UserId });

                var replacementData = new Dictionary<string, object>
                {
                    {
                        "PollName", poll.Name
                    },
                    {
                        "PollDescription", "ergerg"
                    }
                };
                await _mailService.SendEmailAsync(user.User.Email, $"Poll '{poll.Name}' has ended", "pollEnded", replacementData);
            }
            await _pollRepository.UpdateAsync(poll);
        }

        public async Task<int> Create(PollCreateDTO pollCreateDTO)
        {
            string? userId = GetCurrentUserId();
            if (userId is null)
            {
                if (!pollCreateDTO.AllowAnonymous)
                {
                    throw new AccessForbiddenException("You must be logged in to create non anonymous polls");
                }
                if (!pollCreateDTO.ResultsArePublic)
                {
                    throw new AccessForbiddenException("You must be logged in to create polls with non public results");
                }
                if (pollCreateDTO.PollType == PollType.Private || pollCreateDTO.PollType == PollType.Protected)
                {
                    throw new AccessForbiddenException("You must be logged in to create protected and private polls");
                }
                if (pollCreateDTO.StartDate is not null)
                {
                    throw new AccessForbiddenException("You must be logged in to create polls with specific start date");
                }
            }
            Poll newPoll = _mapper.Map<Poll>(pollCreateDTO);
            newPoll.CreatedBy = userId;
            await _pollRepository.AddAsync(newPoll);
            if (newPoll.StartDate is null)
            {
                await OpenPoll(newPoll.Id);
            }
            return newPoll.Id;
        }

        public async Task Delete(int id)
        {
            string? userId = GetCurrentUserId();
            Poll pollToDelete = await _pollRepository.GetByIdAsync(id);
            if (pollToDelete is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if (pollToDelete.CreatedBy != userId || pollToDelete.CreatedBy is null)
            {
                throw new AccessForbiddenException("You do not have permissions to delete this poll");
            }
            await _pollRepository.DeleteAsync(pollToDelete);
        }

        public async Task<PollBaseDTO> Get(int pollId)
        {
            bool isAnonymous = GetCurrentUserId() is null;
            Poll poll = await _pollRepository.GetBySpecAsync(new PollSpecification(x => x.Id == pollId));
            if (poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if (isAnonymous && !poll.AllowAnonymous)
            {
                throw new AccessForbiddenException("You are not allowed to join this poll");
            }
            PollBaseDTO result = _mapper.Map<PollBaseDTO>(poll);
            return result;
        }

        public async Task<PollInfoDTO> GetInfo(int pollId)
        {
            string? userId = GetCurrentUserId();
            Poll poll = await _pollRepository.GetBySpecAsync(new PollSpecification(x => x.Id == pollId));
            if (poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if (userId is null || (poll.CreatedBy != userId || poll.CreatedBy is null) && poll.Moderators.Any(x => x.UserId == userId))
            {
                throw new AccessForbiddenException("You do not have permissions to get this poll info");
            }
            PollInfoDTO result = _mapper.Map<PollInfoDTO>(poll);
            return result;
        }

        public async Task<IEnumerable<PollLiteDTO>> GetAll()
        {
            IEnumerable<Poll> poll = await _pollRepository.GetAllAsync();
            poll = poll.Where(x => x.PollType == PollType.Public);
            IEnumerable<PollLiteDTO> result = _mapper.Map<IEnumerable<PollLiteDTO>>(poll);
            return result;
        }
        public async Task<IEnumerable<PollLiteDTO>> GetMyPolls()
        {
            string? userId = GetCurrentUserId();
            if (userId is null)
            {
                throw new AccessForbiddenException("You must be logged in");
            }
            IEnumerable<Poll> poll = await _pollRepository.GetAllBySpecAsync(new PollSpecification(x =>
                 x.Moderators != null && x.AllowedUsers != null
                && (x.CreatedBy == userId
                || x.Moderators.Any(y => y.UserId == userId)
                || x.AllowedUsers.Any(y => y.UserId == userId))
            ));

            IEnumerable<PollLiteDTO> result = _mapper.Map<IEnumerable<PollLiteDTO>>(poll);
            return result;
        }

        /*public async Task<PollLiteDTO> Update(PollCreateDTO pollCreateDTO, int id)
        {
            string? userId = GetCurrentUserId();
            Poll poll = await _pollRepository.GetByIdAsync(id);
            if (poll is null)
            {
                throw new ObjectNotFoundException();
            }
            if (userId is null || (poll.CreatedBy != userId || poll.CreatedBy is null) && poll.Moderators.Any(x=>x.UserId == userId))
            {
                throw new AccessForbiddenException("You do not have permissions to modify this poll");
            }
            poll.AllowAnonymous = pollCreateDTO.AllowAnonymous;
            poll.EndDate = pollCreateDTO.EndDate;
            poll.Questions = _mapper.Map<List<Question>>(pollCreateDTO.Questions);
            await _pollRepository.UpdateAsync(poll);
            var result = _mapper.Map<PollLiteDTO>(poll);
            return result;
        }*/

        public async Task InviteUsers(int pollId, PollInviteDTO pollInviteDTO)
        {
            string? userId = GetCurrentUserId();
            Poll poll = await _pollRepository.GetBySpecAsync(new PollSpecification(x => x.Id == pollId));
            if (poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if (userId is null || (poll.CreatedBy != userId || poll.CreatedBy is null) && poll.Moderators.Any(x => x.UserId == userId))
            {
                throw new AccessForbiddenException("You do not have permissions to modify this poll");
            }
            if (poll.AllowedUsers is null)
            {
                poll.AllowedUsers = new List<PollAllowed>();
            }
            foreach (string id in pollInviteDTO.UserIds)
            {
                if (!poll.AllowedUsers.Any(x => x.UserId == id))
                {
                    var user = await _userManager.FindByIdAsync(id);
                    if (user is null) continue;
                    poll.AllowedUsers.Add(new PollAllowed() { UserId = id, PollId = poll.Id });

                    await _notificationService.Create(new NotificationCreateDTO() { Title = $"Poll '{poll.Name}' has started", Message = $"The poll: '{poll.Name}' has started.", UserId = user.Id });

                    if (poll.PollType == Core.Enums.PollType.Protected && poll.IsActive)
                    {
                        await SendVotingToken(poll, user);
                    }
                }
            }
            await _pollRepository.UpdateAsync(poll);
        }

        public async Task SetPollModerators(int pollId, PollInviteDTO pollInviteDTO)
        {
            string? userId = GetCurrentUserId();
            Poll poll = await _pollRepository.GetBySpecAsync(new PollSpecification(x => x.Id == pollId));
            if (poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if (userId is null || (poll.CreatedBy != userId || poll.CreatedBy is null) && poll.Moderators.Any(x => x.UserId == userId))
            {
                throw new AccessForbiddenException("You do not have permissions to modify this poll");
            }

            poll.Moderators = new List<PollModerator>();

            foreach (string id in pollInviteDTO.UserIds)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user is null) continue;
                poll.Moderators.Add(new PollModerator() { UserId = id, PollId = poll.Id });
            }
            await _pollRepository.UpdateAsync(poll);
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
