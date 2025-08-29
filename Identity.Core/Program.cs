using IdentityService.Application.Interfaces;
using IdentityService.Infrastructure.Db;
using IdentityService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(IdentityService.Api.Controllers.IdentityController).Assembly);
builder.Services.AddScoped<IdentityService.Application.Services.IdentityService>();
builder.Services.AddOpenApi();

var mongoUri = Environment.GetEnvironmentVariable("MONGO_URI");
var mongoDbName = Environment.GetEnvironmentVariable("MONGO_DB_SUPERNOVA_IDENTITY");

builder.Services.AddSingleton<IIdentityDbContext>(_ => new IdentityDbContext(mongoUri!, mongoDbName!));

builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.MapControllers();

app.Run();