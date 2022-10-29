using Shared.Models;

namespace WebApi.Services;

public class AuthService : IAuthService
{
    private readonly IList<User> users = new List<User>
    {
        new User
        {
            Age = 36,
            Email = "trmo@via.dk",
            Domain = "via",
            Name = "Troels Mortensen",
            Password = "onetwo3FOUR",
            Role = "Teacher",
            Username = "trmo",
            SecurityLevel = 4
        },
        new User
        {
            Age = 34,
            Email = "jakob@gmail.com",
            Domain = "gmail",
            Name = "Jakob Rasmussen",
            Password = "password",
            Role = "Student",
            Username = "jknr",
            SecurityLevel = 2
        }
    };

    public Task<User> ValidateUser(string username, string password)
    {
        User? existing = users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (existing == null)
            throw new Exception("User not found!");

        if (!existing.Password.Equals(password))
            throw new Exception("Password is incorrect!");

        return Task.FromResult(existing);
    }

    public Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            throw new Exception("Username or password is empty!");
        
        users.Add(user);

        return Task.CompletedTask;
    }
}