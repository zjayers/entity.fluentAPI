using System.Data.Entity.ModelConfiguration;
using FluentAPI.Models;

namespace FluentAPI.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            // -- Table Overrides -- //
            // ToTable("tbl_Course");

            // -- Primary Keys -- //
            // HasKey(c => c.Id);

            // -- Property Configurations -- //
            // Mark 'Name' field as required for Courses
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Mark 'Description' as required for Courses
            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            // -- Relationships -- //
            // Set up Foreign Key for AuthorID of Courses (This keeps the columnID from being 'Author_Id")
            HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false); // Disallow deleting Authors if they have any courses available

            // Configure Many To Many relationship between Tags & Courses
            HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m =>
                {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TagId");
                });

            // Configure a 1 to 1 relationship between Course & Cover
            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);
        }
    }
}