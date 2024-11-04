using FlappyBirbServer.Data;
using FlappyBirbServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly FlappyBirbServerContext _context;

    public UsersController(FlappyBirbServerContext context)
    {
        _context = context;
    }

    // POST: api/Users/Register
    [HttpPost("Register")]
    public async Task<ActionResult<User>> Register(User user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    // POST: api/Users/Login
    [HttpPost("Login")]
    public async Task<ActionResult<User>> Login(User user)
    {
        var existingUser = await _context.User.FirstOrDefaultAsync(u => u.Name == user.Name); 

        if (existingUser == null)
        {
            return NotFound("User not found.");
        }

        if (existingUser.Name != user.Name) 
        {
            return Unauthorized();
        }

        return Ok(existingUser);
    }

    private bool UserExists(int id)
    {
        return _context.User.Any(e => e.Id == id);
    }
}
