using Microsoft.Extensions.DependencyInjection;
using Myapp.Data;
using Myapp.DataEF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.DataEF.Extensions
{
    public static class RepoExtensions
    {
        public static void AddRepos(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeesRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IEmployeePhoneRepository, EmployeePhoneRepository>();
            services.AddTransient<IPhoneRepository, PhoneRepository>();
            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
        }
    }
}
