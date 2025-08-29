using MongoDB.Driver;
using AuthService.Domain.Models;

namespace AuthService.Infrastructure.Db;

public interface IAuthDbContext
{
    IMongoCollection<User> Users { get; }
}