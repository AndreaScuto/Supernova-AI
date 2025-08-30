using IdentityService.Application.Interfaces;
using IdentityService.Infrastructure.Db;
using IdentityService.Infrastructure.Interfaces;
using IdentityService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IdentityService.Application.Services.IdentityService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoUri = Environment.GetEnvironmentVariable("MONGO_URI");
var mongoDbName = Environment.GetEnvironmentVariable("MONGO_DB_SUPERNOVA_IDENTITY");

builder.Services.AddSingleton<IIdentityDbContext>(_ => new IdentityDbContext(mongoUri!, mongoDbName!));

builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();