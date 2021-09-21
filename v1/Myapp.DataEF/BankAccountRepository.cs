using Microsoft.EntityFrameworkCore;
using Myapp.Data;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Myapp.DataEF
{
    class BankAccountRepository : IBankAccountRepository
    {

        readonly IBaseRepository<BankAccount> _repository;

        public BankAccountRepository(IBaseRepository<BankAccount> repository)
        {
            _repository = repository;
        }
        public async Task<BankAccount> GetAsync(int id)
        {
            return await _repository.Table.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
