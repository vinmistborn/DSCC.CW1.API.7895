using DSCC.CW1.DAL._7895.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW1.DAL._7895.DalDbContext
{
    //This class allows the API to communicate with the database
    public class ServiceDbContext : DbContext
    {
        //DbContextOptions => configures the connection string and database provider, etc.
        public ServiceDbContext(DbContextOptions options) : base(options)
        {

        }
        //EF Core uses DbSet<Course> to query and save instances of Course table.
        //LINQ Queries used against Course property will be translated into SQL database queries for Course table
        public DbSet<Course> Course { get; set; }
    }
}
