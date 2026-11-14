using Serilog;

namespace nov13.Service;
using static System.Console;
using nov13.DTO;
using nov13.Model;
using System.Linq;
using System.Text.Json;

public class UserService
{
    private List<User> _users = new List<User>();
    private string path = "data/users.json";
    public void UserRegister(RegisterRequest register)
    {
        if (_users.Any(u => u.Login == register.Login))
        {
            Log.Error("User with the same login already exists! - " + register.Login);
            throw new Exception("User with the same login already exists");
        }

        User user = new User(
            register.Name,
            register.LastName,
            register.Bdate,
            register.Email,
            register.Login,
            register.Password);
        _users.Add(user);
        Log.Information($"User {user.Name} created!");
        SaveUsers();
    }

    public User? UserLogin(LoginRequest login)
    {
        User newUser = _users.FirstOrDefault(u => u.Login == login.Login && u.Password == login.Password);
        if (newUser == null)
        {
            Log.Error("Wrong password or login!");
            throw new Exception("Wrong password or login!");
        }

        Log.Information($"User {newUser.Name} logged in!");
        return newUser;
    }
    private void SaveUsers()
    {
        Directory.CreateDirectory("data");
        string json = JsonSerializer.Serialize(_users, new JsonSerializerOptions 
        { 
            WriteIndented = true
        });
        File.WriteAllText(path, json);
    }
    private void LoadUsers()
    {
        if (!File.Exists(path))
            return;

        string json = File.ReadAllText(path);
        _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
    }
    public UserService()
    {
        LoadUsers();
    }
}