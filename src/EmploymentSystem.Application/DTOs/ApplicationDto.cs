using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public int VacancyId { get; set; }
        public int ApplicantId { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
