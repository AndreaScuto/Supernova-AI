using AuthService.Application.Interfaces;
using AuthService.Domain.Models;
using AuthService.Infrastructure.Db;
using MongoDB.Driver;

namespace AuthService.Infrastructure.Repositories;

public class UserRepository(IAuthDbContext context) : IUserRepository
{
    private readonly IAuthDbContext _context = context;

    public async Task<List<User>?> GetAllUsersAsync()
    {
        return await _context.Users.Find(_ => true).ToListAsync();
    }

    public Task<User?> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}