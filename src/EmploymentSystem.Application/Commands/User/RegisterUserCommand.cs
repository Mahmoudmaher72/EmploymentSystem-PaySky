using EmploymentSystem.Application.DTOs;
using MediatR;

namespace EmploymentSystem.Application.Commands.User
{
    public class RegisterUserCommand : IRequest<UserDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; } // "Employer" or "Applicant"
    }
}
