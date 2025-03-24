using SmartWebService.Domain;
using SmartWebService.Infra.Interfaces;
using SmartWebService.Infra.Repositories;

namespace SmartWebService.Bussiness;

public class SecuritySystemService: ISecuritySystem
{
    private readonly SecuritySystemRepository _securitySystem;

    public SecuritySystemService(SecuritySystemRepository securitySystem)
    {
        _securitySystem = securitySystem;
    }

    async Task<SecuritySystem?> ISecuritySystem.GetSystemById(int id)
    {
        return await _securitySystem.GetSystemById(id);
    }
    
    async Task<SecuritySystem?> ISecuritySystem.AddSystem(SecuritySystem securitySystem)
    {
        return await _securitySystem.AddSystem(securitySystem);
    }

    async Task<SecuritySystem?> ISecuritySystem.UpdateSystem(int id, SecuritySystem securitySystem)
    {
        var system = await _securitySystem.GetSystemById(id);
        if (system != null)
        {
            return await _securitySystem.UpdateSystem(id, securitySystem);
        }
        return null;
            
    }

    public async Task<bool?> DeleteSystem(int id)
    {
        return await _securitySystem.DeleteSystem(id);
    }
}