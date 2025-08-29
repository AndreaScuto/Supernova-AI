using IdentityService.Domain.Models;

namespace IdentityService.Application.Interfaces;

public interface IIdentityRepository
{
    public Task<List<User>?> GetAllUsersAsync();
    public Task<User?> GetUserByEmail(string email);
}