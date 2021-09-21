using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Myapp.Data
{
    public interface IBankAccountRepository
    {
        Task<BankAccount> GetAsync(int id);
        
    }
}
