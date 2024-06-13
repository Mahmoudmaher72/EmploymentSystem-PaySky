using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Queries
{
    public class GetVacanciesQueryHandler : IRequestHandler<GetVacanciesQuery, List<VacancyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVacanciesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VacancyDto>> Handle(GetVacanciesQuery request, CancellationToken cancellationToken)
        {
            var vacancies = request.OnlyActive ? await _unitOfWork.Vacancies.GetActiveVacanciesAsync() : await _unitOfWork.Vacancies.GetAllAsync();
            return _mapper.Map<List<VacancyDto>>(vacancies);
        }
    }
}
