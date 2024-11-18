using FlappyBirbServer.Data;
using FlappyBirbServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

[Route("api/[controller]/[action]")]
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
    [HttpPost]
    public async Task<ActionResult> Register(RegisterDTO registerDTO)
    {
        if (registerDTO.Password != registerDTO.ConfirmPassword)
        {
            return BadRequest(new { message = "Les deux mots de passe spécifiés sont différents." });
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

        return Ok(new { message = "L'utilisateur a été enregistré avec succès." });
    }

    // POST: api/Users/Login
    [HttpPost]
    public async Task<ActionResult> Login(LoginDTO loginDTO)
    {
        User user = await _userManager.FindByNameAsync(loginDTO.Username);
        if (user == null)
        {
            return BadRequest(new { message = "L'utilisateur n'existe pas." });
        }
        if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password))
        {
            return BadRequest(new { message = "Le mot de passe est incorrect." });
        }
        else if (user != null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>();
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Une phrase longue et plate que personne ne vas jamais lire"));
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "http://localhost:7059",
                audience: "http://localhost:4200",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        else
        {
            return BadRequest(new { message = "Une erreur s'est produite." });
        }
    }
}
