using ChatbotBuilderEngine.DependencyInjection;
using ChatbotBuilderEngine.Presentation;
using ChatbotBuilderEngine.WebApplicationExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

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

app.UseSerilogRequestLogging();
app.MapGrpcService<WorkflowService>();

await app.RunAsync();