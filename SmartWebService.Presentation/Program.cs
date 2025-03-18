using SmartWebService.Infra;

namespace SmartWebService.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserPersistence userPersistence = new UserPersistence(
                "Ricardo",
                "Santos",
                "ricardo@gmail.com",
                "123456"
            );
        }
    }
}