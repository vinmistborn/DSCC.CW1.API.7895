using DSCC.CW1.API._7895.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW1.API._7895.DalDbContext
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
