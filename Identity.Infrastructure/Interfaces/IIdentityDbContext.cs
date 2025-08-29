using MongoDB.Driver;
using IdentityService.Domain.Models;

namespace IdentityService.Infrastructure.Db;

public interface IIdentityDbContext
{
    IMongoCollection<User> Users { get; }
}