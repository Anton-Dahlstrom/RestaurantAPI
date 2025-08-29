using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.Data;
using RestaurantAPI.DTOs;
using RestaurantAPI.Models;
using RestaurantAPI.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantAPI.Services
{
    public class AuthService(AppDBContext context, IConfiguration config) : IAuthService
    {
        private readonly PasswordHasher<User> _passwordHasher = new();

        public async Task<User?> RegisterAsync(RegisterDTO dto)
        {
            if (context.Users.Any(u => u.Username == dto.Username))
                return null;

            var user = new User
            {
                Username = dto.Username,
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<string?> LoginAsync(LoginDTO dto)
        {
            var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null) return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed) return null;

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(48),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
