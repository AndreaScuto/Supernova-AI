using MongoDB.Driver;
using AuthService.Domain.Models;

namespace AuthService.Infrastructure.Db;

public class AuthDbContext : IAuthDbContext
{
    private readonly IMongoDatabase _database;

    public AuthDbContext(string connectionString, string databaseName)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException(nameof(connectionString));
        if (string.IsNullOrEmpty(databaseName))
            throw new ArgumentNullException(nameof(databaseName));

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
}