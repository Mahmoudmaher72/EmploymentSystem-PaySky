using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Queries
{
    public class GetVacanciesQuery : IRequest<List<VacancyDto>>
    {
        public bool OnlyActive { get; set; } = true;
    }
}
