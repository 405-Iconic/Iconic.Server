using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Courses;

namespace Iconic.Service.DTOs.Courses
{
    public class SubmissionForViewDto : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Attachment Attachment { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
    }
}