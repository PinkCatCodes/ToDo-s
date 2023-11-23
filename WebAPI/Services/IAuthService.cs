

using Domain.Models;

namespace WebAPI.Services;

public interface IAuthService
{//User Import from Shared
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}