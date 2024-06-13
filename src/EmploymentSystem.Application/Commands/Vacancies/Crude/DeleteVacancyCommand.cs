using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Commands.Vacancies
{
    public class DeleteVacancyCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
