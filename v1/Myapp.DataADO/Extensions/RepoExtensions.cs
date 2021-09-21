using Microsoft.Extensions.DependencyInjection;
using Myapp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.DataADO.Extensions
{
    public static class RepoExtensions
    {
        public static void AddRepos(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
