using ChatbotBuilderEngine.DependencyInjection;
using ChatbotBuilderEngine.Presentation;
using ChatbotBuilderEngine.WebApplicationExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddPresentationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

await app.MigrateAsync();

app.MapGrpcService<WorkflowService>();

app.Run();