using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Commands.Vacancies
{
    public class CreateVacancyCommand : IRequest<VacancyDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int MaxApplications { get; set; }
        public int EmployerId { get; set; }
    }
}
