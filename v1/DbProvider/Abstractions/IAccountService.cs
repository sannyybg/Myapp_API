using DbProvider.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbProvider.Abstractions
{
    public interface IAccountService
    {
        Task<(int status, string token)> Authenticate(AccountServiceModel model);
    }
}
