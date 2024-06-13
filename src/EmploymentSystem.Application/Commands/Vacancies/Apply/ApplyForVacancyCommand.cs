using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Commands.Vacancies.Apply
{
    public class ApplyForVacancyCommand : IRequest<ApplicationDto>
    {
        public int VacancyId { get; set; }
        public int ApplicantId { get; set; }
    }
}
