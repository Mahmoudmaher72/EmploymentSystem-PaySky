using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Commands.Vacancies
{
    public class DeactivateVacancyCommand: IRequest<Unit>
    {
        public int VacancyId { get; set; }
    }
}
