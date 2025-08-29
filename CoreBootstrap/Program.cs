using AuthService.Infrastructure.Bootstrap;

namespace CoreBootstrap;

public class Program
{
    static async Task Main(string[] args)
    {
        // Ottieni i servizi pronti all’uso
        var userService = AuthServiceFactory.CreateServices();

        // Esempio: lista utenti
        var users = await userService.GetAllUsersAsync();
        Console.WriteLine($"Utenti trovati: {users.Count}");
    }
}