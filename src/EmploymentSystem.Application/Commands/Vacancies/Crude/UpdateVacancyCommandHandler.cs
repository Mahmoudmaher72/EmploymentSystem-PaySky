using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Domain.IRepositories;
using MediatR;

namespace EmploymentSystem.Application.Commands.Vacancies
{
    public class UpdateVacancyCommandHandler : IRequestHandler<UpdateVacancyCommand, VacancyDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateVacancyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VacancyDto> Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _unitOfWork.Vacancies.GetByIdAsync(request.Id);
            if (vacancy == null)
            {
                throw new Exception("Vacancy not found.");
            }

            vacancy.Title = request.Title;
            vacancy.Description = request.Description;
            vacancy.ExpiryDate = request.ExpiryDate;
            vacancy.MaxApplications = request.MaxApplications;

            _unitOfWork.Vacancies.Update(vacancy);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<VacancyDto>(vacancy);
        }
    }
}
