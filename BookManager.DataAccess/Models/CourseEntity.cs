using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.DataAccess.Models
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;

        public List<LessonEntity> Lessons { get; set; } = [];
        public Guid AuthorId { get; set; }
        public AuthorEntity? Autor { get; set; }
        public List<StudentEntity> Students { get; set; } = [];


    }
}
