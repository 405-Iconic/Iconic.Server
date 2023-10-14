using Iconic.Domain.Commons;
using Iconic.Domain.Entities.Quizes;
using Iconic.Domain.Entitites.Courses;
using System.Collections.Generic;

namespace Iconic.Service.DTOs.Courses
{
    public class LessonForViewDto : Auditable
    {
        public string Documentation { get; set; }
        public int CourseId { get; set; }
        public Attachment Attachment { get; set; }
        public virtual ICollection<VideoForViewDto> Videos { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}