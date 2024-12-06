using ChatbotBuilderEngine.DependencyInjection;
using ChatbotBuilderEngine.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPresentationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.MapGrpcService<WorkflowService>();

app.Run();