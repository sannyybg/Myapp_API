using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Myapp.Data;
using Myapp.DataADO.Models;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Myapp.DataADO
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //ADO
        //private readonly string _connection;
        //public EmployeeRepository(IOptions<ConnectionStrings> options)
        //{
        //    _connection = options.Value.DefaultConnection;
        //}


        //EntityWithStartup
        //private readonly myAppContext _context;
        //public EmployeeRepository(myAppContext context)
        //{
        //    _context = context;
        //}

        private DbContextOptions<myAppContext> _options;
        public EmployeeRepository()
        {
            _options = new DbContextOptionsBuilder<myAppContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=EmployeeManagment; Trusted_Connection=True; MultipleActiveResultSets=true")
                .Options;
        }

        

        //public async Task<List<Employees>> GetAllAsync()
        //{
        //    List<Employees> lst = new List<Employees>();
        //    string sQuery = "select * from Employee";

        //    using (SqlConnection connection = new SqlConnection(_connection))
        //    {
        //        SqlCommand command = new SqlCommand(sQuery, connection);
        //        connection.Open();
        //        SqlDataReader reader = await command.ExecuteReaderAsync();

        //        while (reader.Read())
        //        {
        //            lst.Add(new Employees
        //            {
        //                Id= reader.GetInt32(0),
        //                Name = reader.GetString(1),
        //                Age = reader.GetInt32(2),
        //                Email = reader.GetString(3),
        //                CardNumber = reader.GetString(4),
        //                Phone = reader.GetString(5),
        //                PersonalId = reader.GetString(6)

        //            });
        //        }
        //        reader.Close();
        //        var xx = lst;
        //        return lst;
        //    }

        //}

        public async Task<List<Employees>> GetAllAsync()
        {
            var context = new myAppContext(_options);
           
            var employees = await context.Employee.ToListAsync();
            return employees;
        }

        public async Task<Employees> GetAsync(int id)
        {
            var context = new myAppContext(_options);
            
            var employee = await context.Employee.SingleOrDefaultAsync(x => x.Id == id);
            return employee;
        }

        public async Task<Employees> UpdateAsync(Employees emp)
        {
            var context = new myAppContext(_options);
            
            var currentempl = await context.Employee.FirstOrDefaultAsync(x => x.Id == emp.Id);
            if (currentempl == null)
            {
                await CreateAsync(emp);
            }
            else
            {
                currentempl = emp;
                //context.Employee.Update(emp);
            }
            await context.SaveChangesAsync();
            return emp;
        }

        public async Task<int> CreateAsync(Employees emp)
        {
            var context = new myAppContext(_options);
            
            var empll = await context.Employee.AddAsync(emp);
            await context.SaveChangesAsync();
            return emp.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var context = new myAppContext(_options);
           
            var empl = await context.Employee.FindAsync(id);
            if (empl != null)
            {
                context.Employee.Remove(empl);
            }

            await context.SaveChangesAsync();
        }

        Task IEmployeeRepository.UpdateAsync(Employees emp)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetRelatedPhoneIds(int employeeid)
        {
            throw new NotImplementedException();
        }
    }
}
