using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.IRepositories;
using MediatR;

namespace EmploymentSystem.Application.Commands.Vacancies
{
    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommand, VacancyDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVacancyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VacancyDto> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = _mapper.Map<Vacancy>(request);
            vacancy.IsActive = true;
            await _unitOfWork.Vacancies.AddAsync(vacancy);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<VacancyDto>(vacancy);
        }
    }
}
