using SmartWebService.Domain;

namespace SmartWebService.Infra;

public class UserPersistence
{
    private readonly DbContextInfra _context;

    public UserPersistence(DbContextInfra context)
    {
        _context = context;
    }

    public void CreateUser(string firstName, string surname, string email, string password)
    {
        var user = new User
        {
            Name = firstName,
            Surname = surname,
            Email = email,
            Password = password
        };

        _context.Users.Add(user);
        _context.SaveChanges();
        Console.WriteLine("User created!");
    }
}