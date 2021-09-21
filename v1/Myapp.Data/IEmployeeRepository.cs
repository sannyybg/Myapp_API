using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Myapp.Data
{
    public interface IEmployeeRepository
    {
        Task<List<Employees>> GetAllAsync();
        Task<Employees> GetAsync(int id);
        Task<int> CreateAsync(Employees emp);

        Task DeleteAsync(int id);

        Task UpdateAsync(Employees emp);

        Task<bool> Exists(int id);

        Task<List<int>> GetRelatedPhoneIds(int employeeid);
    }
}
