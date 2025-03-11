using BookManager.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace BookManager.DataAccess.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder.HasKey(a => a.Id);
            // one to one
            builder.HasOne(a => a.Course).WithOne(c => c.Autor).HasForeignKey<CourseEntity>(c => c.AuthorId);
        }
    }
}
