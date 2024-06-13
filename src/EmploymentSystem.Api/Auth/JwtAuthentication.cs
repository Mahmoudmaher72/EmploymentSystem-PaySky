#region Using ...
using EmploymentSystem.Application.Interfaces;
using EmploymentSystem.Domain.IRepositories;
using EmploymentSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

#endregion


namespace EmploymentSystem.Api.Auth
{
    public class JwtAuthentication : Attribute, IAuthorizationFilter
    {
        private readonly string _role;

        public JwtAuthentication(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var request = context.HttpContext.Request;
            var authorization = request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authorization) || !authorization.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var token = authorization.Substring("Bearer ".Length).Trim();
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = tokenHandler.ReadJwtToken(token);

                if (jwtToken == null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;

                if (roleClaim == null || roleClaim != _role)
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
