using Microsoft.EntityFrameworkCore;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.DataADO
{
    public class myAppContext :DbContext
    {

        public myAppContext(DbContextOptions<myAppContext> options)
            : base(options)
        {

        }
        public DbSet<Employees> Employee { get; set; }
    }
}
