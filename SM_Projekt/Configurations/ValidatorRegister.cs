using Application.DTO;
using Application.DTOs.Poll;
using Application.DTOs.User;
using Application.DTOs.Vote;
using Application.Validators;
using Application.Validators.Authentication;
using Application.Validators.Poll;
using Application.Validators.User;
using Application.Validators.Vote;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Newtonsoft.Json.Converters;
using System.Reflection;

namespace SM_Projekt.Configurations
{
    public static class ValidatorRegister
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.Converters.Add(new StringEnumConverter())).AddFluentValidation(c =>
            {
                c.DisableDataAnnotationsValidation = true;
                c.RegisterValidatorsFromAssemblyContaining<IValidator>();
                // Optionally set validator factory if you have problems with scope resolve inside validators.
                c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
            });

            services.AddFluentValidationRulesToSwagger();
        }
    }
}
