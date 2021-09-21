using Microsoft.EntityFrameworkCore;
using Myapp.Data;
using Myapp.Domain.POCO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myapp.DataEF
{
    public class EmployeesRepository : IEmployeeRepository
    {

        readonly IBaseRepository<Employees> _repository;

        public EmployeesRepository(IBaseRepository<Employees> repository)
        {
            _repository = repository;
        }


        public async Task<int> CreateAsync(Employees emp)
        {
            await _repository.AddAsync(emp);
            return emp.Id;
        }

        public Task DeleteAsync(int id)
        {
            return _repository.RemoveAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repository.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Employees>> GetAllAsync()
        {
            //return await _repository.GetAllAsync();
            return await _repository.Table
                .Include(x => x.Accounts)
                .Include(x => x.EmployeePhones)
                .ThenInclude(x => x.Phone)
                .ToListAsync();
        }

        public async Task<Employees> GetAsync(int id)
        {
            //return await _repository.GetAsync(id);
            return await _repository.Table
                .Include(x => x.Accounts)
                .Include(x => x.EmployeePhones)
                .ThenInclude(x => x.Phone)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public Task UpdateAsync(Employees emp)
        {
            return _repository.UpdateAsync(emp);
        }

        public async Task<List<int>> GetRelatedPhoneIds(int employeeid)
        {
            return await _repository.Table.Where(x => x.Id == employeeid).SelectMany(x => x.EmployeePhones).Select(x => x.PhoneId).ToListAsync();
        }


    }
}
