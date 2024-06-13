using EmploymentSystem.Application.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return Unauthorized(new { message = result.Message });
            }

            return Ok(new { token = result.Data });
        }
    }
}
