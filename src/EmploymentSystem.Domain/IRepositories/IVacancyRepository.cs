using EmploymentSystem.Domain.Entities;
using System.Linq.Expressions;

namespace EmploymentSystem.Domain.IRepositories
{
    public interface IVacancyRepository : IRepository<Vacancy>
    {
        Task<IEnumerable<Vacancy>> FindAsync(Expression<Func<Vacancy, bool>> predicate);
        Task<List<Vacancy>> GetActiveVacanciesAsync();
    }
}
