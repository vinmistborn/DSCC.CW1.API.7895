using DSCC.CW1.DAL._7895.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW1.DAL._7895.DalDbContext
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions options) : base(options)
        {

        }        
        public DbSet<Course> Course { get; set; }
    }
}
