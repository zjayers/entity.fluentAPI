using System.Data.Entity;
using DataAnnotations;
using FluentAPI.EntityConfigurations;
using FluentAPI.Models;

namespace FluentAPI
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new CourseConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}