using EmploymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.IRepositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByIdAsync(int id);
        Task<Role> GetRoleByNameAsync(string name);
    }
}
