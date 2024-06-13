using EmploymentSystem.Application.DTOs;
using MediatR;

namespace EmploymentSystem.Application.Commands.User
{
    public class LoginCommand : IRequest<Result<string>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
