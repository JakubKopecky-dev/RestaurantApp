using MenuService.Query.Infrastructure.Elastic;
using MenuService.Query.SyncWorker.DependecyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransitService(builder.Configuration);
builder.Services.AddElastic(builder.Configuration);



var app = builder.Build();


app.Run();
