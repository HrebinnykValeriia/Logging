using Serilog;

namespace nov13.Utils;

using nov13.Service;
using nov13.Model;
using nov13.DTO;

public class FakeUserTest
{
    private UserService _service;

    public FakeUserTest(UserService service)
    {
        _service = service;
    }

    public void Run()
    {
        List<User> fakeUsers = GenFakeUser.GenUsers(10);
        Console.WriteLine($"Generated users: {fakeUsers.Count}");
        foreach (User user in fakeUsers)
        {
            try
            {
                Console.WriteLine(user);
                RegisterRequest request = new RegisterRequest(user.Name, user.LastName, user.Bdate, user.Email,
                    user.Login, user.Password);
                _service.UserRegister(request);
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to register fake user");  
            }
            
        }
    }
}