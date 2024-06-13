using EmploymentSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateJWTToken(UserDto userDto, int expire_in_Minutes = (60 * 6));
    }
}
