using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.IRepositories;
using EmploymentSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace EmploymentSystem.Infrastructure.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly ApplicationDbContext _context;

        public VacancyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vacancy> GetByIdAsync(int id)
        {
            return await _context.Vacancies.Include(v => v.Employer).SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Vacancy>> GetAllAsync()
        {
            return await _context.Vacancies.Include(v => v.Employer).ToListAsync();
        }

        public async Task<List<Vacancy>> GetActiveVacanciesAsync()
        {
            return await _context.Vacancies.Where(v => v.IsActive && v.ExpiryDate > DateTime.Now).ToListAsync();
        }

        public async Task AddAsync(Vacancy vacancy)
        {
            await _context.Vacancies.AddAsync(vacancy);
        }

        public void Update(Vacancy vacancy)
        {
            _context.Vacancies.Update(vacancy);
        }

        public void Delete(Vacancy vacancy)
        {
            _context.Vacancies.Remove(vacancy);
        }

        public async Task<IEnumerable<Vacancy>> FindAsync(Expression<Func<Vacancy, bool>> predicate)
        {
            return await _context.Vacancies.Where(predicate).ToListAsync();
        }
    }
}
