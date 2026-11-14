namespace nov13.Model;

public record User(string Name, string LastName, DateOnly Bdate, string Email, string Login, string Password)
{
    public override string ToString()
    {
        return $"\n{Name} {LastName} was born in {Bdate} ({Email})\nlogin: {Login}\nPassword: {Password}";
    }
}
