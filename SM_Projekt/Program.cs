using Application.DTO;
using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using Application.Validators.User;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scrutor;
using SM_Projekt.Helpers;
using Core.Repositories.Base;
using Infrastructure.Repositories.Base;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.ImplicitlyValidateChildProperties = true;
    fv.ImplicitlyValidateRootCollectionElements = true;

    fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    // Other way to register validators
    //fv.RegisterValidatorsFromAssemblyContaining<Startup>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SM Projekt", Version = "v1" });
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

builder.Services.Scan(scan => scan
                .FromAssembliesOf(typeof(Repository<>))
                .AddClasses(publicOnly: true)
                .AsMatchingInterface((repository, filter) =>
                    filter.Where(implementation => implementation.Name.Equals($"I{repository.Name}", StringComparison.OrdinalIgnoreCase)))
                .WithTransientLifetime());

builder.Services.Scan(scan => scan
                .FromAssemblyOf<IService>()
                .AddClasses(publicOnly: true)
                .AsMatchingInterface((service, filter) =>
                    filter.Where(implementation => implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
                .WithTransientLifetime());


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddTransient<IValidator<UserCreateDTO>, UserCreateValidator>();

builder.Services.AddDbContext<IdentityDbContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("RemoteConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});

var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{

    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

MapperConfiguration mapperConfig = new (mc =>
{
    mc.AddProfile(new UserMappingProfile());
    mc.AddProfile(new AnswerMappingProfile());
    mc.AddProfile(new QuestionMappingProfile());
    mc.AddProfile(new PollMappingProfile());
    mc.AddProfile(new VoteMappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());


app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }

