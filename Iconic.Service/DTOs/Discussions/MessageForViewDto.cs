using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.Discussions;
using Iconic.Domain.Entitites.Users;
using Iconic.Service.DTOs.Users;

namespace Iconic.Service.DTOs.Discussions
{
    public class MessageForViewDto : Auditable
    {
        public Attachment Media { get; set; }
        public string Content { get; set; }
        public int ChatId { get; set; }
        public UserForViewDTO Freelancer { get; set; }
        public TeacherForViewDTO Teacher { get; set; }
    }
}