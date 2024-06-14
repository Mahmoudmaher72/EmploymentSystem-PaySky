using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Interfaces
{
    public interface IExpiredVacanciesService
    {
        Task ManageExpiredVacancies();
    }
}
