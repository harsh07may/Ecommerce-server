using Ecommerce_server.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce_server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        public async Task<User> CreateUser(UserDto newUser)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            User user = new()
            {
                PasswordHash = passwordHash,
                Username = newUser.Username
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>?> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return null;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();

        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<string?> Login(UserDto existingUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == existingUser.Username);
            if (user is null)
            {
                return null;
            }
            if (!BCrypt.Net.BCrypt.Verify(existingUser.Password, user.PasswordHash))
            {
                return null;
            }
            string token = CreateToken(user);
            return token;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.PrimarySid, Convert.ToString(user.UserId))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
