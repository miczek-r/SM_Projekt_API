using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Base;
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
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<UserRepository, UserRepositoryImp>();
builder.Services.AddTransient<AuthenticationService, AuthenticationServiceImp>();
builder.Services.AddTransient<UserService, UserServiceImp>();

builder.Services.AddTransient<IValidator<UserCreateDTO>, UserCreateValidator>();

builder.Services.AddDbContext<IdentityDbContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

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
    options.User.RequireUniqueEmail = false;
});

MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new UserMappingProfile());
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

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }