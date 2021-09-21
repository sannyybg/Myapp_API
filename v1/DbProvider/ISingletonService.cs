using DbProvider.VirtualDTO;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbProvider
{
    public interface ISingletonService<T>
    {

        Task<List<Employee>> GetAllAsync();
        Task<int> CreateAsync(Employee emp);

        Task<string> DeleteAsync(int id);

        Task<Employee> GetAsync(int id);

        Task<int> UpdateAsync(Employee emp);

    }
}
