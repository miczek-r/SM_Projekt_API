using SM_Projekt.Helpers;

using SM_Projekt.Configurations;

var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    var port = Environment.GetEnvironmentVariable("PORT");
    builder.WebHost.UseUrls("http://*:" + port);
}

builder.Services.RegisterValidators();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterSwagger();
builder.Services.RegisterScrutor();
builder.Services.RegisterContextAccessor();
builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterIdentity();
builder.Services.RegisterAuthentication(builder.Configuration);
builder.Services.RegisterMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (/*app.Environment.IsDevelopment()*/true)
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

