using Application.DTOs.Answer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Poll
{
    public class AnswerCreateValidator : AbstractValidator<AnswerCreateDTO>
    {
        public AnswerCreateValidator()
        {
            RuleFor(x => x.Text).NotEmpty();
        }
    }
}
