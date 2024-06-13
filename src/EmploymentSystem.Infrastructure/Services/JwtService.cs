using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EmploymentSystem.Infrastructure.Services
{
    public class JwtService: IJwtService
    {
        public const string SecretKey = "JIOBLi6eVjBpvGtWBgJzjWd2QH0sOn5tI8rIFXSHKijXWEt/3J2jFYL79DQ1vKu+EtTYgYkwTluFRDdtF41yAQ==";

        public string GenerateJWTToken(UserDto userDto, int expire_in_Minutes = (60 * 6))
        {
            var symmetric_Key = Convert.FromBase64String(SecretKey);
            var token_Handler = new JwtSecurityTokenHandler();

            var now = DateTime.Now;
            var securitytokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, userDto.Id.ToString()),
                            new Claim("Role", userDto.RoleName)

                        }),

                Expires = now.AddMinutes(Convert.ToInt32(expire_in_Minutes)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetric_Key), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = token_Handler.CreateToken(securitytokenDescriptor);
            var token = token_Handler.WriteToken(stoken);

            return token;
        }
    }
}
