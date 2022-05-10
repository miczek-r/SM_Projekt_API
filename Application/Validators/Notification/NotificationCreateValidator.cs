using Application.DTOs.Notification;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Notification
{
    public class NotificationCreateValidator : AbstractValidator<NotificationCreateDTO>
    {
        public NotificationCreateValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Message).NotEmpty();
        }
    }
}
