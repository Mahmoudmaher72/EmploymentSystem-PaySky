using EmploymentSystem.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Commands.Vacancies
{
    public class DeleteVacancyCommandHandler : IRequestHandler<DeleteVacancyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVacancyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _unitOfWork.Vacancies.GetByIdAsync(request.Id);
            if (vacancy == null)
            {
                throw new Exception("Vacancy not found.");
            }

            _unitOfWork.Vacancies.Delete(vacancy);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
