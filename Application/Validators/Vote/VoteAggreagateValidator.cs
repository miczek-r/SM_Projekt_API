﻿using Application.DTOs.Vote;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Vote
{
    public class VoteAggregateValidator : AbstractValidator<VoteAggregateDTO>
    {
        public VoteAggregateValidator()
        {
            RuleFor(x => x.Votes).NotNull();
            RuleFor(x => x.Votes).Must(x=> x.Any()).When(x => x.Votes is not null).WithMessage("At least one vote is required");
            RuleFor(x => x.PollId).NotNull();
            RuleForEach(x => x.Votes).SetValidator(new VoteCreateValidator()).When(x=> x.Votes is not null);
        }
    }
}
