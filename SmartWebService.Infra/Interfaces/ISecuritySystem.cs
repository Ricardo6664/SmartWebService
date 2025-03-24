using SmartWebService.Domain;

namespace SmartWebService.Infra.Interfaces;

public interface ISecuritySystem
{
    Task<SecuritySystem?> GetSystemById(int id);
    
    Task<SecuritySystem?> AddSystem(SecuritySystem securitySystem);
    
    Task<SecuritySystem?> UpdateSystem(int id, SecuritySystem securitySystem);
    
    Task<bool?> DeleteSystem(int id);
    
}