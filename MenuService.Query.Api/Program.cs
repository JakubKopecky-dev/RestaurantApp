using MenuService.Query.Api.GraphQL;
using MenuService.Query.Api.Middleware;
using MenuService.Query.Api.Types;
using MenuService.Query.Application;
using MenuService.Query.Infrastructure;
using MenuService.Query.Infrastructure.Elastic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddElastic(builder.Configuration);

builder.Services.AddInfrastuctureServices();

builder.Services.AddAplicationServices();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<MenuType>();



var app = builder.Build();

// Client cancellation logging
app.UseClientCancellationLogging();


using var scope = app.Services.CreateScope();
var bootstrapper = scope.ServiceProvider.GetRequiredService<ElasticBootstrapper>();
await bootstrapper.EnsureIndicesExistAsync();

app.UseHttpsRedirection();
app.MapGraphQL();



app.Run();
