using FlappyBirbServer.Data;
using FlappyBirbServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly FlappyBirbServerContext _context;

    public UsersController(FlappyBirbServerContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // POST: api/Users/Register
    [HttpPost("Register")]
    public async Task<ActionResult> Register(RegisterDTO registerDTO)
    {


        if (registerDTO.Password != registerDTO.ConfirmPassword)
        {
            return BadRequest("Les deux mots de passe spécifiés sont différents.");
        }

        User user = new User
        {
            UserName = registerDTO.Username,
            Email = registerDTO.Email
        };

        IdentityResult identityResult = await _userManager.CreateAsync(user, registerDTO.Password);

        if (!identityResult.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new
                {
                    Status = "Error",
                    Message = "La création a échoué. Errors: " +
                              string.Join(", ", identityResult.Errors.Select(e => e.Description))
                });
        }

        return Ok("L'utilisateur a été enregistré avec succès.");
    }
}
