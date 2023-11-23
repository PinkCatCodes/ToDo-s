namespace Shared.Dtos;

public class UserLoginDto
{
    public string Username { get; init; }
    public string Password { get; init; }
}/*Notice the init;. This is a specific kind of set;, 
meaning you can only set this values, when the object 
is created, but not later modify it. It is not strictly 
necessary, but in general it is good practice to only allow 
what is supposed to be available. We don't intend to change 
the values after creation, so we don't allow that.
 It is just a minor detail. You could just use a constructor
  instead. I was feeling fancy.*/