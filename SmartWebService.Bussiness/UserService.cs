using SmartWebService.Domain;
using SmartWebService.Infra.Interfaces;
using SmartWebService.Infra.Repositories;

namespace SmartWebService.Bussiness;

public class UserService : IUser
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User?> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<User> AddUser(User user)
    {
        return await _userRepository.AddUser(user);
        
    }

    public async Task<User?> UpdateUser(int id, User updateUser)
    {
        var user = await _userRepository.GetUserById(id);
        if (user != null)
        {
            return await _userRepository.UpdateUser(id, updateUser);
        }
        return null;
    }

    public async Task<bool> DeleteUser(int id)
    {
        return await _userRepository.DeleteUser(id);
    }
}