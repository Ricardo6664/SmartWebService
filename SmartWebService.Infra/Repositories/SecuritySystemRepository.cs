using Microsoft.EntityFrameworkCore;
using SmartWebService.Domain;
using SmartWebService.Infra.Interfaces;

namespace SmartWebService.Infra.Repositories;

public class SecuritySystemRepository(DbContextInfra context): ISecuritySystem
{
    public async Task<SecuritySystem?> GetSystemById(int id)
    {
        return await context.Set<SecuritySystem>().FirstOrDefaultAsync(u => u.ID == id);
    }

    public async Task<SecuritySystem?> AddSystem(SecuritySystem securitySystem)
    {
        await context.Set<SecuritySystem>().AddAsync(securitySystem);
        await context.SaveChangesAsync();
        return securitySystem;
    }

    public async Task<SecuritySystem?> UpdateSystem(int id, SecuritySystem securitySystem)
    {
        var existingSystem = await context.Set<SecuritySystem>().FirstOrDefaultAsync(u => u.ID == id);
        if(existingSystem == null) return null;
        existingSystem.NameSystem = securitySystem.NameSystem;
        existingSystem.Description = securitySystem.Description;
        context.Update(existingSystem);
        
        await context.SaveChangesAsync();
        return existingSystem;
    }

    public async Task<bool?> DeleteSystem(int id)
    {
        var existingSystem = context.Set<SecuritySystem>().FirstOrDefaultAsync(u => u.ID == id);
        if (existingSystem == null) return false;
        context.Remove(existingSystem);
        await context.SaveChangesAsync();
        return true;
    }
}