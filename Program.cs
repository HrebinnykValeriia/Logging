using System.Data.SqlTypes;
using nov13.Service;
using Serilog;
using Serilog.Core;
using nov13.Model;
using nov13.Utils;

/*
 користуввач:
 ім'я, Призвіще, Дата народження, емейл, логін, пароль - (реєстрація)
 логін, пароль - (авторизація) (record - DTO)

 */
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/applog-.json", rollingInterval: RollingInterval.Hour)
    .CreateLogger();
try
{
    Log.Information("App started");
    UserService service = new UserService();
    GenFacts facts = new GenFacts();
    Menu menu = new Menu(service, facts);
    
    menu.ShowMenu();
    
}
catch (Exception ex)
{
    Log.Fatal(ex, "An error occurred");
}
finally
{
    Log.CloseAndFlush();
}
