using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.Entities
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public int MaxApplications { get; set; }
        public int EmployerId { get; set; }
        public User Employer { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
