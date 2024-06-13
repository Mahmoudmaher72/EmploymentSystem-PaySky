using EmploymentSystem.Application.DTOs;
using MediatR;

namespace EmploymentSystem.Application.Queries
{
    public class GetApplicantsForVacancyQuery : IRequest<List<ApplicantDto>>
    {
        public int VacancyId { get; set; }
    }
}
