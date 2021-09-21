using Microsoft.EntityFrameworkCore;
using Myapp.Data;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Myapp.DataEF
{
    class EmployeePhoneRepository : IEmployeePhoneRepository
    {
        readonly IBaseRepository<EmployeePhone> _repo;


        public EmployeePhoneRepository(IBaseRepository<EmployeePhone> repo)
        {
            _repo = repo;
        }

        public void SetModifiedState(EmployeePhone entity)
        {
            _repo.SetState(entity, EntityState.Modified);
        }

        public async Task CreateAsync(EmployeePhone entity)
        {
            await _repo.AddAsync(entity);
        }

        public async Task<bool> ExistsAnotherOwner(int personId, int phoneId)
        {
            return await _repo.AnyAsync(x => x.EmployeeId != personId && x.PhoneId == phoneId);
        }
    }
}
