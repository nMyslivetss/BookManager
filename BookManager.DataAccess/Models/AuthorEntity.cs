namespace BookManager.DataAccess.Models
{
    public class AuthorEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public CourseEntity? Course { get; set; }

    }
}
