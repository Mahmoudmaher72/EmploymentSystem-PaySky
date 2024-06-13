using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public int VacancyId { get; set; }
        public virtual Vacancy Vacancy { get; set; }
        public int ApplicantId { get; set; }
        public virtual User Applicant { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
