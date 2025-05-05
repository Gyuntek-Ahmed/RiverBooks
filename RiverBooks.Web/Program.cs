using FastEndpoints;
using RiverBooks.Books;
using RiverBooks.Users;
using Serilog;

var loger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

loger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) =>
config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();

// Add Module Services
builder.Services.AddBookServices(builder.Configuration);
builder.Services.AddUsersModuleServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.UseFastEndpoints();
app.Run();

public partial class Program { }