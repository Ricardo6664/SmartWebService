using Microsoft.EntityFrameworkCore;
using SmartWebService.Domain;
using SmartWebService.Infra.Interfaces;
using BCrypt.Net;

namespace SmartWebService.Infra.Repositories
{
    public class UserRepository(DbContextInfra context) : IUser
    {
        public async Task<User> AddUser(User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;
            await context.Set<User>().AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return false;
            
            context.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<User?> GetUserById(Guid id)
        {
            return await context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User?> UpdateUser(Guid id, User user)
        {
            var existingUser = await context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null) return null;
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
                
            context.Update(existingUser);
            await context.SaveChangesAsync();
            return existingUser;
        }
    }
}