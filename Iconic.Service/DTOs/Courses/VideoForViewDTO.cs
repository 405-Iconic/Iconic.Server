using Iconic.Domain.Commons;

namespace Iconic.Service.DTOs.Courses
{
    public class VideoForViewDto : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public int Length { get; set; }
        public int ViewCount { get; set; }
        public string Url { get; set; }
        public int LessonId { get; set; }
    }
}