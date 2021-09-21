using DbProvider.Abstractions;
using DbProvider.Implementations;
using DbProvider.VirtualDTO;
using Microsoft.Extensions.DependencyInjection;
using Myapp.DataEF.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProvider.serviceExtensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(ISingletonService<Employee>), typeof(DbProvider<Employee>));
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IJWTService, JWTService>();

            services.AddRepos();
        }
    }
}
