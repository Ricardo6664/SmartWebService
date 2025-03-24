using System;
using System.Threading.Tasks;
using SmartWebService.Infra.Interfaces;
using SmartWebService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace SmartWebService.Presentation.Controller;

[Route("v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUser _userService;

    public UserController(IUser userService)
    {
        _userService = userService;
    }

    // GET: api/user/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
            return NotFound("User not found");
        return user;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User updateUser)
    {
        var user = await _userService.UpdateUser(id, updateUser);
        if (user == null) return NotFound(new { message = "User not found." });
        
        return Ok(user);
    }

    // POST: api/user
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        var createdUser = await _userService.AddUser(user);
        return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
    }

    // DELETE: api/user/{id}
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var result = await _userService.DeleteUser(id);
        if (result)
        {
            return Ok("User deleted");
        }
        return NotFound("User not found");
    }
}