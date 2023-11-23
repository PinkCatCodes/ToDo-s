namespace Domain.DTOs;

public class UserCreationDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
//prop
    public UserCreationDto(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public UserCreationDto()
    {
        
    }

   
}