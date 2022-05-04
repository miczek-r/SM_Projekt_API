using Application.DTOs.Vote;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Enums;
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
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IPollRepository _pollRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public VoteService(IVoteRepository voteRepository, IPollRepository pollRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _voteRepository = voteRepository;
            _pollRepository = pollRepository;
            _contextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<VoteInfoDTO> Get(int pollId)
        {
            string? userId = GetCurrentUserId();

            Poll poll = await _pollRepository.GetBySpecAsync(new PollSpecification(x => x.Id == pollId));
            if (poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exist");
            }
            if (!poll.ResultsArePublic && poll.CreatedBy != userId && !(poll.Moderators?.Any(x => x.UserId == userId) ?? false))
            {
                throw new AccessForbiddenException("You are not allowed to view this poll results");
            }
            List<Vote> votes = new();
            ICollection<VoteQuestionInfoDTO> voteQuestions = new List<VoteQuestionInfoDTO>();
            foreach (var question in poll.Questions)
            {
                var votesInQuestion = await _voteRepository.GetByLambdaAsync(x => x.QuestionId == question.Id);
                votes.AddRange(votesInQuestion);
                var test = new VoteQuestionInfoDTO
                {
                    QuestionId = question.Id,
                    QuestionText = question.Text,
                    QuestionType = question.Type,
                    Answers = votesInQuestion.GroupBy(x => x.Answer).Select(group => new VoteAnswerInfoDTO { AnswerId = group.Key.Id, AnswerText = group.Key.Text, Count = group.Count() }).ToList()
                };
                voteQuestions.Add(test);
            }

            ICollection<VoteBaseDTO> baseAnswers = _mapper.Map<ICollection<VoteBaseDTO>>(votes);
            return new VoteInfoDTO { BaseAnswers = baseAnswers, VoteQuestions = voteQuestions };
        }

        public async Task VoteSingle(VoteCreateDTO vote)
        {
            string? userId = GetCurrentUserId();

            //TODO: If not allowed to vote in this poll throw error
            await Vote(vote, userId);
        }

        public async Task VoteAggregate(VoteAggregateDTO votes)
        {
            string? userId = GetCurrentUserId();
            Poll poll = await _pollRepository.GetByIdAsync(votes.PollId);
            if(poll is null)
            {
                throw new ObjectNotFoundException("This poll does not exists");
            }
            if(!poll.AllowAnonymous && userId is null)
            {
                throw new ObjectValidationException("You must be logged in to vote in this poll");
            }
            if (votes.Votes is null)
            {
                throw new ObjectValidationException("There are no votes");
            }
            if (userId is not null && (await _voteRepository.GetByLambdaAsync(x => x.UserId == userId && x.Question.PollId == votes.PollId)).Any())
            {
                throw new ObjectAlreadyExistsException("You already voted in this poll");
            }
            foreach (var vote in votes.Votes)
            {
                await Vote(vote, userId);
            }
        }
        private async Task Vote(VoteCreateDTO vote, string? userId)
        {
            Vote newVote = _mapper.Map<Vote>(vote);
            newVote.UserId = userId;
            await _voteRepository.AddAsync(newVote);
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
