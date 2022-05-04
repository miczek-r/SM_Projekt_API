using Application.DTO;
using Application.Validators.User;
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
        }
    }
}
