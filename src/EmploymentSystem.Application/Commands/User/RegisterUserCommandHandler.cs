using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.IRepositories;

using MediatR;

namespace EmploymentSystem.Application.Commands.User
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.Roles.GetRoleByNameAsync(request.RoleName);
            if (role == null)
            {
                throw new Exception("Invalid role specified.");
            }

            var user = new Domain.Entities.User
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Email = request.Email,
                RoleId = role.Id
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UserDto>(user);
        }
    }
}
