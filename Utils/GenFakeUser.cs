namespace nov13.Utils;
using nov13.Model;
public class GenFakeUser
{
    public static string[] names =
    {
        "Olivia", "James", "Sophia", "William", "Lejla",
        "Emma", "Oliver", "Mia", "Lucas", "Selma", "Daniel"
    };

    public static string[] lastNames =
    {
        "Williams",
        "Zimmerman",
        "Day",
        "Caldwell",
        "Coleman",
        "Cross",
        "Long",
        "Smith",
        "Jones",
        "King"
    };

    public static string[] emails =
    {
        "gigixe1978@jcaton.com",
        "norval.james62@gmail.com",
        "maybelle_flatley@yahoo.com",
        "eveline42@gmail.com",
        "dave59@hotmail.com",
        "billie_hayes71@gmail.com",
        "chaz_doyle@gmail.com",
        "donnie.littel@yahoo.com",
        "myriam_skiles37@gmail.com",
        "maiya38@yahoo.com"
    };

    public static string[] logins =
    {
        "CalmEcho5",
        "RareScout181",
        "DigitalSpirit86",
        "DarkGhost45",
        "Github",
        "ThunderNode598",
        "RapidByte30",
        "QuantumApex918",
        "PrimalByte479",
        "CosmicApex851"
    };

    public static string[] passwords =
    {
        "tN${",
        "ny(~",
        "hKUp",
        "gj2§",
        "R8&4",
        "Xdz§",
        "M=a:",
        "{Fej",
        "ATQ9",
        ")Uxh"
    };
    static Random random = new Random();

    public static string GenName()
    {
        return names[random.Next(0, names.Length)];
    }
    public static string GenLastName()
    {
        return lastNames[random.Next(0, lastNames.Length)];
    }

    public static string GenEmail()
    {
        return emails[random.Next(0, emails.Length)];
    }

    public static string GenLogin()
    {
        return logins[random.Next(0, logins.Length)];
    }

    public static string GenPassword()
    {
        return passwords[random.Next(0, passwords.Length)];
    }
    public static DateOnly GenBdate()
    {
        DateOnly startDate = new DateOnly(1980, 1, 1);
        DateOnly endDate = new DateOnly(2005, 12, 31);

        int days = random.Next(0, endDate.DayNumber - startDate.DayNumber + 1);
        return startDate.AddDays(days);
    }

    public static User GenUser()
    {
        return new User(GenName(), GenLastName(), GenBdate(), GenEmail(), GenLogin(), GenPassword());
    }
    public static List<User> GenUsers(int count)
    {
        List<User> list = new();
        for (int i = 0; i < count; ++i)
        {
            list.Add(GenUser());
        }
        return list;
    }
}