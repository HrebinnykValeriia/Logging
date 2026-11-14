using nov13.DTO;
using Serilog;
using nov13.Utils;

namespace nov13.Service;

using static System.Console;
using nov13.Service;
using nov13.Model;

public class Menu
{
    private UserService service;
    private GenFacts facts;

    public Menu(UserService serviceU, GenFacts factsU)
    {
        service = serviceU;
        facts = factsU;
    }

    public void ShowMenu()
    {
        string menuText = """
                          Welcome!
                          1. Registration
                          2. Login
                          3. Fake users test
                          0. Exit

                          Enter your choice: 
                          """;
        do
        {
            try
            {
                WriteLine(menuText);
                int choice = int.Parse(ReadLine() ?? "");
                if (choice == 0)
                {
                    WriteLine("Goodbye!");
                    Log.Information("User left");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        WriteLine("Registration");
                        Register();
                        break;

                    case 2:
                        WriteLine("Login");
                        Login();
                        break;
                    case 3:
                        WriteLine("Fake users test: ");
                        FakeUserTest test = new FakeUserTest(service);
                        test.Run();
                        break;

                    default:
                        WriteLine("Invalid option!");
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteLine($"Error: {ex.Message}");
            }

            ReadKey();
            Clear();
        } while (true);
    }

    public void Register()
    {
        WriteLine("Please enter a username: ");
        string username = ReadLine() ?? "";

        WriteLine("Please enter a last name: ");
        string lastName = ReadLine() ?? "";

        WriteLine("Please enter a birth date:");
        DateOnly bdate = DateOnly.Parse(ReadLine() ?? "");

        WriteLine("Please enter an email: ");
        string email = ReadLine() ?? "";

        WriteLine("Please enter a login: ");
        string login = ReadLine() ?? "";
        string password;
        while (true)
        {
            WriteLine("Please enter a password: ");
            password = ReadLine() ?? "";

            WriteLine("Please confirm your password: ");
            string confirmPassword = ReadLine() ?? "";

            if (password == confirmPassword)
            {
                break;
            }

            WriteLine("Passwords do not match! Try again.");
        }

        RegisterRequest request = new RegisterRequest(username, lastName, bdate, email, login, password);

        service.UserRegister(request);
        WriteLine("Registration complete!");
    }

    public void Login()
    {
        WriteLine("Please enter a login: ");
        string login = ReadLine() ?? "";
        WriteLine("Please enter a password: ");
        string password = ReadLine() ?? "";

        LoginRequest request = new LoginRequest(login, password);
        User? user = service.UserLogin(request);

        if (user == null)
        {
            WriteLine("Login failed!");
        }
        else
        {
            WriteLine($"Welcome {user.Name}\nHere's an interesting fact for you: \n");
            WriteLine(facts.GenFact());
        }
    }
}