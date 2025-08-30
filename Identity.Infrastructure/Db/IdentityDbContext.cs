using MongoDB.Driver;
using IdentityService.Domain.Models;
using IdentityService.Infrastructure.Interfaces;

namespace IdentityService.Infrastructure.Db;

public class IdentityDbContext : IIdentityDbContext
{
    private readonly IMongoDatabase _database;

    public IdentityDbContext(string connectionString, string databaseName)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException(nameof(connectionString));
        if (string.IsNullOrEmpty(databaseName))
            throw new ArgumentNullException(nameof(databaseName));

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
        _database.CreateCollection("Users");
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
}