using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class Context: IdentityDbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }


        // Optional
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Test_System;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
