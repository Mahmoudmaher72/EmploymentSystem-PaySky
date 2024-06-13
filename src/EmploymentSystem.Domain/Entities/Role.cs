using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } // "Employer" or "Applicant"
        public virtual ICollection<User> Users { get; set; }
    }

}
