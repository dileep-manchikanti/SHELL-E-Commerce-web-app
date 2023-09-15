using Bootcamp_Project.EF_Core;
using Bootcamp_Project.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bootcamp_Project.Service
{
    public class AuthService:ControllerBase
    {
        private readonly EF_DataContext _context;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public AuthService(EF_DataContext context, ILogger logger,IConfiguration configuration)
        {

            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public string GenerateToken(LoginRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]); // Replace with your secret key

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Email, request.email),
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
