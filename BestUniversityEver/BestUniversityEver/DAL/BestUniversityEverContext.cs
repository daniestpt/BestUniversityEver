using BestUniversityEver.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BestUniversityEver.DAL
{
    public class BestUniversityEverContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Grade> Grade { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BestUniversityEverContext>(null);
            base.OnModelCreating(modelBuilder);
            //TODO: This blocks all 1-N Cascade Deletes. See if this is the correct thing to do! 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}