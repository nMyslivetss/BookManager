using BookManager.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.DataAccess.Repositories
{
    public class CoursesRepository
    {
        private readonly LearningDbContext _dbContext;

        public CoursesRepository(LearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CourseEntity>> Get()
        {
            return await _dbContext.Cources
                .AsNoTracking()
                .OrderBy(c => c.Title)
                .ToListAsync();
        }

        public async Task<List<CourseEntity>> GetWithLessons()
        {
            return await _dbContext.Cources
                .AsNoTracking()
                .Include(c => c.Lessons)
                .ToListAsync();
        }

        public async Task<CourseEntity?> GetById(Guid id)
        {
            return await _dbContext.Cources
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CourseEntity>> GetByFilter(string title, decimal price)
        {
            var query = _dbContext.Cources.AsNoTracking();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(c => c.Title.Contains(title));
            }

            if (price > 0)
            {
                query = query.Where(c => c.Price > price);
            }

            return await query.ToListAsync();
        }

        public async Task<List<CourseEntity>> GetByPage(int page, int pageSize)
        {
            return await _dbContext.Cources
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            
        }

        public async Task Add(Guid id, Guid authorId, string title, string description, decimal price)
        {
            var courseEntity = new CourseEntity
            {
                Id = id,
                AuthorId = authorId,
                Title = title,
                Description = description,
                Price = price
            };
            await _dbContext.AddAsync(courseEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Guid id, Guid authorId, string title, string description, decimal price)
        {
            await _dbContext.Cources
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Title, title)
                    .SetProperty(c => c.Description, description)
                    .SetProperty(c => c.Price, price));

            await _dbContext.SaveChangesAsync();
        }
    }
}
