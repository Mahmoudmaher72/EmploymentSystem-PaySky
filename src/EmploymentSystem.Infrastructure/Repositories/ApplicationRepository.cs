using EmploymentSystem.Domain.IRepositories;
using EmploymentSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmploymentSystem.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Application> GetByIdAsync(int id)
        {
            return await _context.Applications.Include(a => a.Applicant).Include(a => a.Vacancy).SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Domain.Entities.Application>> GetAllAsync()
        {
            return await _context.Applications.Include(a => a.Applicant).Include(a => a.Vacancy).ToListAsync();
        }

        public async Task<List<Domain.Entities.Application>> GetApplicationsByVacancyIdAsync(int vacancyId)
        {
            return await _context.Applications.Where(a => a.VacancyId == vacancyId).Include(a => a.Applicant).ToListAsync();
        }

        public async Task<List<Domain.Entities.Application>> GetApplicationsByApplicantIdAsync(int applicantId)
        {
            return await _context.Applications.Where(a => a.ApplicantId == applicantId).ToListAsync();
        }

        public async Task AddAsync(Domain.Entities.Application application)
        {
            await _context.Applications.AddAsync(application);
        }

        public void Update(Domain.Entities.Application application)
        {
            _context.Applications.Update(application);
        }

        public void Delete(Domain.Entities.Application application)
        {
            _context.Applications.Remove(application);
        }
    }
}
