using StudentManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StudentManagementSystem.Database
{
    public class SMSDbContext : DbContext
    {
        public SMSDbContext(DbContextOptions<SMSDbContext> option) : base(option)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasOne(d => d.department).WithMany(s => s.students).HasForeignKey(f => f.DepartmentId);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasMany(s => s.students).WithOne(d => d.department).IsRequired();
            base.OnModelCreating(modelBuilder);

            

        }
    }
}
