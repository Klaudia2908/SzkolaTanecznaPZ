using DancingSchool.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DancingSchool.dal
{
    public class PortalContext:DbContext
    {
        public PortalContext() : base("PortalContext")
        {
        }
            public DbSet<People> People { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<School> Schools { get; set; }
            public DbSet<Enrolment> Enrolments { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}
