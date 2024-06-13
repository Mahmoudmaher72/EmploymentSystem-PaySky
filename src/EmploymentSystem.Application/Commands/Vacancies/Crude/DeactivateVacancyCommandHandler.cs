using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Domain.IRepositories;
using MediatR;

namespace EmploymentSystem.Application.Commands.Vacancies
{
    public class DeactivateVacancyCommandHandler : IRequestHandler<DeactivateVacancyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeactivateVacancyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeactivateVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _unitOfWork.Vacancies.GetByIdAsync(request.VacancyId);

            if (vacancy == null)
            {
                throw new Exception("Vacancy not found.");
            }

            vacancy.IsActive = false;
            _unitOfWork.Vacancies.Update(vacancy);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
                                                        