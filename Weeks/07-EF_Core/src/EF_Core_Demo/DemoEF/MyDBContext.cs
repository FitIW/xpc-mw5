using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF
{
    public class MyDBContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) 
        { 

        }
    }
}
