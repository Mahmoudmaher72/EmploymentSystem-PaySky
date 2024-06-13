using EmploymentSystem.Domain.IRepositories;
using EmploymentSystem.Infrastructure.Context;
using System;

namespace EmploymentSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
            Vacancies = new VacancyRepository(context);
            Applications = new ApplicationRepository(context);
            Roles = new RoleRepository(context);
        }

        public IUserRepository Users { get; private set; }
        public IVacancyRepository Vacancies { get; private set; }
        public IApplicationRepository Applications { get; private set; }
        public IRoleRepository Roles { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
