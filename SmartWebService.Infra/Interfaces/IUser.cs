using SmartWebService.Domain;

namespace SmartWebService.Infra.Interfaces
{
    public interface IUser
    {
        Task<User?> GetUserById(Guid id);
        
        Task<User> AddUser(User user);
        
        Task<User?> UpdateUser(Guid id, User user);
        
        Task<bool> DeleteUser(Guid id);
    }
}