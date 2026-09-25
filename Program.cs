using InventoryHub.Application;
using InventoryHub.Infrastructure;
using InventoryHub.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentationServices()
    .AddApplicationServices()
    .AddInfrastructureServices();

var app = builder.Build();

app.UsePresentationMiddleware();

await DbInitializer.SeedInitialDataAsync(app.Services);

app.Run();
