using MongoDB.Driver;
using IdentityService.Domain.Models;

namespace IdentityService.Infrastructure.Interfaces;

public interface IIdentityDbContext
{
    IMongoCollection<User> Users { get; }
}