using SmartWebService.Domain;

namespace SmartWebService.Infra;

public class UserPersistence
{
    public UserPersistence(string firstName, string surname, string email, string password)
    {
        var user = new User
        {
            Name = firstName,
            Surname = surname,
            Email = email,
            Password = password
        };

        using (var context = new DbContextInfra())
        {
            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine("User created!");
        }
    }
}