using AuthService.Application.Interfaces;
using AuthService.Domain.Models;

namespace AuthService.Application.Services;

public class UserService(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task<List<User>?> GetAllUsersAsync()
    {
        return await _repository.GetAllUsersAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _repository.GetUserByEmail(email);
    }
}