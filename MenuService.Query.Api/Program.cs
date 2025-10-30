using MenuService.Query.Application;
using MenuService.Query.Infrastructure;
using MenuService.Query.Infrastructure.Elastic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastuctureServices();

builder.Services.AddAplicationServices();


var app = builder.Build();



using var scope = app.Services.CreateScope();
var bootstrapper = scope.ServiceProvider.GetRequiredService<ElasticBootstrapper>();
await bootstrapper.EnsureIndicesExistAsync();


app.Run();
