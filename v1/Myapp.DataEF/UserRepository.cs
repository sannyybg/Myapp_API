using Microsoft.EntityFrameworkCore;
using Myapp.Data;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myapp.DataEF
{
    public class UserRepository : IUserRepository
    {
        readonly IBaseRepository<User> _repository;

        public UserRepository(IBaseRepository<User> repository)
        {
            _repository = repository;
        }


        public async Task<User> GetByUserPass(string userName, string password)
        {
            return await _repository.Table.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();
        }
    }
}
