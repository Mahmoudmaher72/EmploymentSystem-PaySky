using EmploymentSystem.Api.Auth;
using EmploymentSystem.Application.Commands.Vacancies;
using EmploymentSystem.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtAuthentication("Employer")]
    public class EmployerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-vacancy")]
        public async Task<IActionResult> CreateVacancy([FromBody] CreateVacancyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("applicant-vacancies/{vacancyid}")]
        public async Task<IActionResult> GetApplicantsForVacancy(int vacancyid)
        {
            var query = new GetApplicantsForVacancyQuery { VacancyId = vacancyid };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("deactivate-vacancy/{id}")]
        public async Task<IActionResult> DeactivateVacancy(int id)
        {
            var command = new DeactivateVacancyCommand { VacancyId = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("update-vacancy")]
        public async Task<IActionResult> UpdateVacancy([FromBody] UpdateVacancyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete-vacancy/{id}")]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            var command = new DeleteVacancyCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
