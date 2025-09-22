using System.ComponentModel.DataAnnotations;
using IdentityService.Domain.Enums;

namespace IdentityService.Domain.Models;

public sealed class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    [EmailAddress] [MaxLength(256)] public string Email { get; private set; } = null!;
    [MaxLength(256)] public string NormalizedEmail { get; private set; } = null!;

    public bool EmailConfirmed { get; private set; }

    //TODO: Insert Password hashing
    public string Password { get; private set; } = null!;
    public Role Role { get; private set; } = Role.User;
    public string SecurityStamp { get; private set; } = Guid.NewGuid().ToString("N");
    [Timestamp] public byte[] RowVersion { get; private set; } = Array.Empty<byte>();
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? LastLoginAt { get; private set; }
    public int AccessFailedCount { get; private set; }
    public DateTimeOffset? LockoutEndDate { get; private set; }

    private User()
    {
    }

    public static User Create(string email, string password, Role role)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));

        return new User
        {
            Email = email.Trim(),
            NormalizedEmail = email.Trim().ToUpperInvariant(),
            Password = password,
            Role = role
        };
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
        Email = email.Trim();
        NormalizedEmail = email.Trim().ToUpperInvariant();
        EmailConfirmed = false;
        SecurityStamp = Guid.NewGuid().ToString("N");
    }

    public void ConfirmEmail()
    {
        if (!EmailConfirmed) EmailConfirmed = true;
    }

    public bool IsEmailConfirmed() => EmailConfirmed;

    public void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));
        Password = password;
        SecurityStamp = Guid.NewGuid().ToString("N");
    }

    public void SetRole(Role role)
    {
        if (Role == role) return;
        Role = role;
        SecurityStamp = Guid.NewGuid().ToString("N");
    }


    public void ResetAccessFailedCount()
    {
        AccessFailedCount = 0;
        LastLoginAt = DateTimeOffset.UtcNow;
    }

    public void ResetLockoutEndDate()
    {
        LockoutEndDate = null;
    }

    public void RegisterLoginSuccess(DateTimeOffset now)
    {
        AccessFailedCount = 0;
        LastLoginAt = now;
        LockoutEndDate = null;
    }

    public void RegisterLoginFailure(DateTimeOffset now)
    {
        AccessFailedCount++;
        LockoutEndDate = AccessFailedCount switch
        {
            >= 3 and < 5 => now + TimeSpan.FromMinutes(2),
            >= 5 => now + TimeSpan.FromMinutes(10),
            _ => LockoutEndDate
        };
    }
}