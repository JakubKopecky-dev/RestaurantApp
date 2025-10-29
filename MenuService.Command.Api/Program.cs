using MenuService.Command.Application;
using MenuService.Command.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceService(builder.Configuration);

builder.Services.AddApplicationService();



var app = builder.Build();


app.Run();
