using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class User
{
    public int Id { get; set; }
    [MaxLength(10)]
    public string UserName { get; set; }
    
    public string Password { get; set; }
   [JsonIgnore]
    public ICollection<Todo> Todos { get; set; }

    public User()
    {
        
    }
   
   /*
   public string Email { get; set; }
    public string Domain { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }
    public int SecurityLevel { get; set; }*/
}