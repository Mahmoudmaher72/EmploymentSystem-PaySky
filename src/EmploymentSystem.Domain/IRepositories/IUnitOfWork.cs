using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IVacancyRepository Vacancies { get; }
        IApplicationRepository Applications { get; }
        IRoleRepository Roles { get; }
        Task<int> CompleteAsync();
    }
}
