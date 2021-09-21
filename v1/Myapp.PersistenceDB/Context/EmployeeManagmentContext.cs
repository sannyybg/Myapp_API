using Microsoft.EntityFrameworkCore;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.PersistenceDB.Context
{
    public class EmployeeManagmentContext : DbContext
    {

        private readonly string _connectionString;


        public EmployeeManagmentContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public EmployeeManagmentContext(DbContextOptions<EmployeeManagmentContext> options) : base(options)
        {

        }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeManagmentContext).Assembly);
        }


        public DbSet<Employees> Employees { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Phone> Phone { get; set; }

        public DbSet<EmployeePhone> EmployeePhone { get; set; }
        public DbSet<BankAccount> Accounts { get; set; }


    }
}
