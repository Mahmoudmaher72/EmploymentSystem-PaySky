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
    public class GetApplicantsForVacancyQueryHandler : IRequestHandler<GetApplicantsForVacancyQuery, List<ApplicantDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetApplicantsForVacancyQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ApplicantDto>> Handle(GetApplicantsForVacancyQuery request, CancellationToken cancellationToken)
        {
            var applications = await _unitOfWork.Applications.GetApplicationsByVacancyIdAsync(request.VacancyId);
            var applicants = applications.Select(a => a.Applicant).ToList();
            return _mapper.Map<List<ApplicantDto>>(applicants);
        }
    }
}
