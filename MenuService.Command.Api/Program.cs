using MenuService.Command.Api.DepndecyInjection;
using MenuService.Command.Api.GraphQL;
using MenuService.Command.Api.Middleware;
using MenuService.Command.Application;
using MenuService.Command.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddMassTransitService(builder.Configuration);

builder.Services
    .AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>();





var app = builder.Build();

// Client cancellation logging
app.UseClientCancellationLogging();

app.UseHttpsRedirection();
app.MapGraphQL();

app.Run();
