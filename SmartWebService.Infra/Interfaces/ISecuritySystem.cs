using SmartWebService.Domain;

namespace SmartWebService.Infra.Interfaces;

public interface ISecuritySystem
{
    Task<User?> GetUserById(int id);
}