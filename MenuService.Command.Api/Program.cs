using MenuService.Command.Application;
using MenuService.Command.Persistence;
using MenuService.Command.Api.GraphQL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services
    .AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>();





var app = builder.Build();

app.UseHttpsRedirection();
app.MapGraphQL();

app.Run();
