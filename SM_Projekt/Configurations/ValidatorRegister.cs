using Application.DTO;
using Application.DTOs.Poll;
using Application.DTOs.Vote;
using Application.Validators.Poll;
using Application.Validators.User;
using Application.Validators.Vote;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace SM_Projekt.Configurations
{
    public static class ValidatorRegister
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;

                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            });

            services.AddTransient<IValidator<UserCreateDTO>, UserCreateValidator>();
            services.AddTransient<IValidator<PollCreateDTO>, PollCreateValidator>();
            services.AddTransient<IValidator<VoteAggregateDTO>, VoteAggregateValidator>();
        }
    }
}
