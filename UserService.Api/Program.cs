using UserService.Infrastructure;
using UserService.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersisteceService(builder.Configuration);

builder.Services.AddInfrastructureServices();

var app = builder.Build();

// Authentitaction and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.Run();
