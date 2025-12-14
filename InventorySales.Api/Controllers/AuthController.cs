using InventorySales.Api.DTOs;
using InventorySales.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public AuthController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username && u.PasswordHash == loginDto.Password); // Plain text for demo

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                Token = "dummy-token-12345" // In real app, generate JWT
            });
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == registerDto.Username))
            {
                return BadRequest("Username already exists");
            }

            var user = new Data.Entities.User
            {
                Username = registerDto.Username,
                PasswordHash = registerDto.Password, // Plain text for demo
                Role = registerDto.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role
            });
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await _context.Users
                .Select(u => new UserDto { Id = u.Id, Username = u.Username, Role = u.Role })
                .ToListAsync();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
