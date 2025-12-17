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
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            try 
            {
                // Try standard BCrypt verification
                if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                {
                    return Unauthorized("Invalid credentials");
                }
            }
            catch (BCrypt.Net.SaltParseException)
            {
                // FALLBACK: If salt is invalid, it's likely old plain-text
                // We compare directly. If it matches, we allow it (and ideally should update the hash)
                if (user.PasswordHash != loginDto.Password)
                {
                    return Unauthorized("Invalid credentials");
                }
                
                // Optional: Auto-Update to new hash standard
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(loginDto.Password);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

            return Ok(new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                Token = "dummy-token-12345" 
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
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
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
        public async Task<ActionResult<List<UserDto>>> GetAll([FromQuery] int? id, [FromQuery] string? name)
        {
            var query = _context.Users.AsQueryable();

            if (id.HasValue)
            {
                query = query.Where(u => u.Id == id.Value);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(u => u.Username.Contains(name));
            }

            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            
            var users = await query.ToListAsync();
            var dtos = new List<UserDto>();

            foreach(var u in users)
            {
                // Give 1 point for each sale records in the current month
                var points = await _context.Sales
                    .CountAsync(s => s.UserId == u.Id && s.Date >= startOfMonth);

                dtos.Add(new UserDto 
                { 
                    Id = u.Id, 
                    Username = u.Username, 
                    Role = u.Role,
                    PerformancePoints = points
                });
            }

            return Ok(dtos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegisterDto updateDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            // Check if username taken by another user
            if (await _context.Users.AnyAsync(u => u.Username == updateDto.Username && u.Id != id))
            {
                return BadRequest("Username already exists");
            }

            user.Username = updateDto.Username;
            if (!string.IsNullOrEmpty(updateDto.Password))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateDto.Password);
            }
            user.Role = updateDto.Role;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return NoContent();
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
