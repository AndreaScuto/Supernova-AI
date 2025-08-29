using IdentityService.Application.Interfaces;
using IdentityService.Domain.Models;

namespace IdentityService.Application.Services;

public class IdentityService(IIdentityRepository repository)
{
    public async Task<List<User>?> GetAllUsersAsync()
    {
        return await repository.GetAllUsersAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await repository.GetUserByEmail(email);
    }
}