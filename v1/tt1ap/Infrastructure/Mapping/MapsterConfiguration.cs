using DbProvider.Models;
using DbProvider.VirtualDTO;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tt1ap.Models;

namespace tt1ap.Infrastructure.Mapping
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<Employee, EmployeeModel>
            .NewConfig()
            .TwoWays()
            .Map(dest => dest.PhoneNumber, sr => sr.Phone);


            TypeAdapterConfig<Employees, Employee>
            .NewConfig();




            TypeAdapterConfig <Employee, Employees>
            .NewConfig()
            .Map(dest => dest.EmployeePhones,
            src => src.Phones != null ? src.Phones.Select(x => new EmployeePhone { Phone = x.Adapt<Phone>(), EmployeeId = src.Id, PhoneId = x.Id }) : default);

            TypeAdapterConfig<Employees, Employee>
            .NewConfig()
            .Map(dest => dest.Phones,
            src => src.EmployeePhones.Select(x => x.Phone));


            TypeAdapterConfig<PhoneRequest, PhoneServiceModel>
            .NewConfig()
            .TwoWays()
            .Map(dest => dest.Type, src => src.TypeId);


            TypeAdapterConfig<Phone, PhoneServiceModel>
           .NewConfig()
           .TwoWays()
           .Map(dest => dest.Type, src => src.TypeId);



            TypeAdapterConfig<BankAccountServiceModel, BankAccount>
            .NewConfig()
            .TwoWays()
            .Ignore(x => x.Employee);


            TypeAdapterConfig<BankAccountRequest, BankAccountServiceModel>
            .NewConfig()
            .TwoWays();





            TypeAdapterConfig<AccountServiceModel, User>
           .NewConfig()
           .TwoWays();

            TypeAdapterConfig<AccountServiceModel, AccountRequest>
           .NewConfig()
           .TwoWays();



        }
    }
}
