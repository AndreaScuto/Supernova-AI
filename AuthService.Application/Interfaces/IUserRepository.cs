using AuthService.Domain.Models;

namespace AuthService.Application.Interfaces;

public interface IUserRepository
{
    public Task<List<User>?> GetAllUsersAsync();
    public Task<User?> GetUserByEmail(string email);
}