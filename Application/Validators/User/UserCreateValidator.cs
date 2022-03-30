using Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.User
{
    public class UserCreateValidator : AbstractValidator<UserCreateDTO>
    {
        public UserCreateValidator()
        {
            RuleFor(x=> x.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
}
