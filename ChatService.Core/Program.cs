using Application.Interfaces;
using Application.Services;
using Infrastructure.Db;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<ChatService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoUri = Environment.GetEnvironmentVariable("MONGO_URI");
var mongoDbName = Environment.GetEnvironmentVariable("MONGO_DB_SUPERNOVA_CHAT");

builder.Services.AddSingleton<IChatDbContext>(_ => new ChatDbContext(mongoUri!, mongoDbName!));
builder.Services.AddScoped<IChatRepository, ChatRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();