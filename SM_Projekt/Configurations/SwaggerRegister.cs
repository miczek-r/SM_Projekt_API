using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace SM_Projekt.Configurations
{
    public static class SwaggerRegister
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            var info = new OpenApiInfo()
            {
                Title = "API for SM Project",
                Version = "v1",
                Description = "API for SM Project.",
                Contact = new OpenApiContact() { Name = "Rafał Miczek", Email = "miczek.r@gmail.com" },
                License = new OpenApiLicense() { Name = "GNU General Public License", Url = new Uri("https://opensource.org/licenses/gpl-license") }
            };
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.SwaggerDoc("v1", info);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                            {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }
    }
}
