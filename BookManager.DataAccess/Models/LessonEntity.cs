namespace BookManager.DataAccess.Models
{
    public class LessonEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string LessonText { get; set; } = string.Empty;
        public Guid CourseId { get; set; }
        public CourseEntity? Course { get; set; }

    }
}
