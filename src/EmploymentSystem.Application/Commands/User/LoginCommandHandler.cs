using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.Interfaces;
using EmploymentSystem.Domain.IRepositories;
using MediatR;

namespace EmploymentSystem.Application.Commands.User
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetUserByUsernameAsync(request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Result<string>.Failure("Invalid username or password.");
            }

            var userDto = _mapper.Map<UserDto>(user);
            var token = _jwtService.GenerateJWTToken(userDto);

            return Result<string>.Success(token);
        }
    }
}
