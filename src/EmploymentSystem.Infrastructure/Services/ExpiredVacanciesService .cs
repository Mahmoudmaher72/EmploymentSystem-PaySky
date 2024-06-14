using EmploymentSystem.Application.Interfaces;
using EmploymentSystem.Domain.IRepositories;

namespace EmploymentSystem.Infrastructure.Services
{
    public class ExpiredVacanciesService : IExpiredVacanciesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _logger;

        public ExpiredVacanciesService(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task ManageExpiredVacancies()
        {
            var currentDate = DateTime.Now;
            var expiredVacancies = await _unitOfWork.Vacancies.FindAsync(v => v.ExpiryDate <= currentDate && v.IsActive);

            foreach (var vacancy in expiredVacancies)
            {
                vacancy.IsActive = false;
                _unitOfWork.Vacancies.Update(vacancy);
            }

            await _unitOfWork.CompleteAsync();
            _logger.LogInfo("Managed expired vacancies.");
        }
    }
}
