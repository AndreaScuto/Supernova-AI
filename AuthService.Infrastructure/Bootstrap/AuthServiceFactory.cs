using AuthService.Application.Services;
using AuthService.Infrastructure.Db;
using AuthService.Infrastructure.Repositories;

namespace AuthService.Infrastructure.Bootstrap;

public static class AuthServiceFactory
{
    public static UserService CreateServices()
    {
        var conn = Environment.GetEnvironmentVariable("MONGO_URI")
                   ?? throw new InvalidOperationException("MONGO_URI non definito");

        var dbName = Environment.GetEnvironmentVariable("MONGO_DB_SUPERNOVA_AUTH")
                     ?? throw new InvalidOperationException("MONGO_DB_SUPERNOVA_AUTH non definito");

        IAuthDbContext authDbContext = new AuthDbContext(conn, dbName);
        var userRepository = new UserRepository(authDbContext);
        var userService = new UserService(userRepository);

        return userService;
    }
}