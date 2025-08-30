using Domain.Models;
using Infrastructure.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Db;

public class ChatDbContext : IChatDbContext
{
    private readonly IMongoDatabase _database;

    public ChatDbContext(string connectionString, string databaseName)
    {
        if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
        {
            throw new ArgumentNullException("ConnectionString or DatabaseName are null or empty!\n" +
                                            "connectionString:" + connectionString + "\ndatabaseName:" + databaseName);
        }

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
        _database.CreateCollection("Chats");
    }

    public IMongoCollection<Chat> Chats => _database.GetCollection<Chat>("Chats");
}