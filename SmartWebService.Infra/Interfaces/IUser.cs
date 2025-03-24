using SmartWebService.Domain;

namespace SmartWebService.Infra.Interfaces
{
    public interface IUser
    {
        Task<User?> GetUserById(int id);
        
        Task<User> AddUser(User user);
        
        Task<User?> UpdateUser(int id, User user);
        
        Task<bool> DeleteUser(int id);
    }
}