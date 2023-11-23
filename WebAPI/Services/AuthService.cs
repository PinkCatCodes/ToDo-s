using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using EfcData.DAOs;


namespace WebAPI.Services;

public class AuthService : IAuthService
{

    private readonly IUserDao userdao;
    
    public AuthService(IUserDao userdao)
    {
        this.userdao = userdao;
    }
    
    private readonly IList<User> users = new List<User>
    {
       /* new User
        {
            Age = 36,
            Email = "trmo@via.dk",
            Domain = "via",
            Name = "Troels Mortensen",
            Password = "onetwo3FOUR",
            Role = "Teacher",
            UserName = "trmo",
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
            UserName = "jknr",
            SecurityLevel = 2
        }*/
    };
// works on login
    public async Task<User> ValidateUser(string username, string password)
    {

        //var existingUser = await userdao.GetByUsernameAsync(username);

       
        var _users = await userdao.GetAsync(new SearchUserParametersDto(username));
        User? existingUser = _users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
       
        if (existingUser == null)
        {
            throw new Exception("User does not exist");
        }

        
        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Wrong password!");
        }
// return Task.FromResult(existingUser); gives error because of async and await
        return existingUser;
    }
    
    
    
   //this works on creating user . gives error that user exists
    
    /*if (existingUser!=null)
        {
            throw new Exception("User already exists");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Wrong password!");
        }

      
       return existingUser;*/

    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        users.Add(user);
        
        return Task.CompletedTask;
    }
}