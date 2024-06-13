using EmploymentSystem.Api.Auth;
using EmploymentSystem.Application.Commands.Vacancies.Apply;
using EmploymentSystem.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtAuthentication("Applicant")]
    public class ApplicantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("vacancies")]
        public async Task<IActionResult> GetVacancies([FromQuery] GetVacanciesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("apply-vacancy")]
        public async Task<IActionResult> ApplyForVacancy([FromBody] ApplyForVacancyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
