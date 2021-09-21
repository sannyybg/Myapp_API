using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Myapp.Data
{
    public interface IEmployeePhoneRepository
    {
        void SetModifiedState(EmployeePhone entity);

        Task CreateAsync(EmployeePhone entity);
        Task<bool> ExistsAnotherOwner(int empId, int phoneId);
    }
}
