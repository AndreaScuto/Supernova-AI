using IdentityService.Application.Interfaces;
using IdentityService.Domain.Models;
using IdentityService.Infrastructure.Db;
using IdentityService.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace IdentityService.Infrastructure.Repositories;

public class IdentityRepository(IIdentityDbContext context) : IIdentityRepository
{
    public async Task<List<User>?> GetAllUsersAsync()
    {
        return await context.Users.Find(_ => true).ToListAsync();
    }

    public Task<User?> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}