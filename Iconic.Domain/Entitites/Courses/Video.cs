using Iconic.Domain.Commons;

namespace Iconic.Domain.Entitites.Courses
{
    public class Video : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public int Length { get; set; }
        public int ViewCount { get; set; }
        public string Url { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}