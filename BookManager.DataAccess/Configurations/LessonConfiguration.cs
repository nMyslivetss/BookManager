using BookManager.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.DataAccess.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
    {
        public void Configure(EntityTypeBuilder<LessonEntity> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(l => l.Course).WithMany(c => c.Lessons).HasForeignKey(l => l.CourseId);

        }
    }
}
