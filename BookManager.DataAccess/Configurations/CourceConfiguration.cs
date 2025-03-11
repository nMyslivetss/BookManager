using BookManager.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.DataAccess.Configurations
{
    public class CourceConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Autor).WithOne(c => c.Course).HasForeignKey<CourseEntity>(c => c.AuthorId);
            builder.HasMany(c => c.Lessons).WithOne(l => l.Course).HasForeignKey(l => l.CourseId);
            // many to many
            builder.HasMany(c => c.Students).WithMany(s => s.Courses);
        }
    }
}
