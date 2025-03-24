using SmartWebService.Infra.Interfaces;
using SmartWebService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace SmartWebService.Presentation.Controller;

[Route($"v1/security/[controller]")]
[ApiController]
public class SecuritySystemController: ControllerBase
{

    private readonly ISecuritySystem _securitySystem;

    public SecuritySystemController(ISecuritySystem securitySystem)
    {
        _securitySystem = securitySystem;
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<SecuritySystem>> GetSecuritySystem(int id)
    {
        var user = await _securitySystem.GetSystemById(id);
        if (user == null) return NotFound("System not found");
        return user;
    }

    [HttpPut("[action]/{id}")]
    public async Task<ActionResult<SecuritySystem>> UpdateSecuritySystem(int id,
        [FromBody] SecuritySystem securitySystem)
    {
        var system = await _securitySystem.UpdateSystem(id, securitySystem);
        if (system == null) return NotFound(new { message = "System not found" });
        return Ok(system);
    }

    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> AddSecuritySystem([FromBody] SecuritySystem securitySystem)
    {
        var createdSystem = await _securitySystem.AddSystem(securitySystem);
        return CreatedAtAction(nameof(GetSecuritySystem), new {id = createdSystem.ID}, createdSystem);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteSecuritySystem(int id)
    {
        var deletedSystem = await _securitySystem.DeleteSystem(id);
        if (deletedSystem == true)
        {
            return Ok(new { message = "System deleted" });
        }
        return NotFound(new { message = "System not found" });
    } 
}