using Domain.Models;
using MongoDB.Driver;

namespace Infrastructure.Interfaces;

public interface IChatDbContext
{
    IMongoCollection<Chat> Chats { get; }
}