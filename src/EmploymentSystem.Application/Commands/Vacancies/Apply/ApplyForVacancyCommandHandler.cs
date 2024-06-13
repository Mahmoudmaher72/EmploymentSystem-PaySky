using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Domain.IRepositories;
using MediatR;

namespace EmploymentSystem.Application.Commands.Vacancies.Apply
{
    public class ApplyForVacancyCommandHandler : IRequestHandler<ApplyForVacancyCommand, ApplicationDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplyForVacancyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApplicationDto> Handle(ApplyForVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _unitOfWork.Vacancies.GetByIdAsync(request.VacancyId);
            if (vacancy == null || !vacancy.IsActive || vacancy.ExpiryDate <= DateTime.Now)
            {
                throw new Exception("Vacancy is not available.");
            }

            var existingApplications = await _unitOfWork.Applications.GetApplicationsByVacancyIdAsync(request.VacancyId);
            if (existingApplications.Count >= vacancy.MaxApplications)
            {
                throw new Exception("Vacancy has reached the maximum number of applications.");
            }

            var today = DateTime.Today;
            var applicantApplications = await _unitOfWork.Applications.GetApplicationsByApplicantIdAsync(request.ApplicantId);
            if (applicantApplications.Any(a => a.ApplicationDate >= today))
            {
                throw new Exception("Applicant can only apply for one vacancy per day.");
            }

            var application = new Domain.Entities.Application
            {
                VacancyId = request.VacancyId,
                ApplicantId = request.ApplicantId,
                ApplicationDate = DateTime.Now
            };

            await _unitOfWork.Applications.AddAsync(application);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ApplicationDto>(application);
        }
    }
}
