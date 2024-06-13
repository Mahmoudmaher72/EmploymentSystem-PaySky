using EmploymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.IRepositories
{
    public interface IApplicationRepository : IRepository<Application>
    {
        Task<List<Application>> GetApplicationsByVacancyIdAsync(int vacancyId);
        Task<List<Application>> GetApplicationsByApplicantIdAsync(int applicantId);
    }
}
