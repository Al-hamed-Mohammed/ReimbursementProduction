
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<TimeSheet> Timesheet { get; set; }

        public DbSet<Mileage> Mileage { get; set; }
        public DbSet<ErrorLogs> ErrorLogs { get; set; }
        public DbSet<Accountants> Accountants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
