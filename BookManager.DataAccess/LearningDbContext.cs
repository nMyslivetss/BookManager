using BookManager.DataAccess.Configurations;
using BookManager.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManager.DataAccess
{
    public class LearningDbContext : DbContext
    {
        public LearningDbContext(DbContextOptions<LearningDbContext> options) : base(options)
        {
            
        }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<CourseEntity> Cources { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<StudentEntity> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new CourceConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
