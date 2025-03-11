using BookManager.DataAccess.Models;

namespace BookManager.DataAccess.Repositories
{
    public class LessonsRepository
    {
        private readonly LearningDbContext _dbContext;

        public LessonsRepository(LearningDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddLesson(Guid courseId, string title)
        {
            var lesson = new LessonEntity
            {
                Title = title,
                CourseId = courseId
            };

            await _dbContext.AddAsync(lesson);
            await _dbContext.SaveChangesAsync();
        }
    }
}
