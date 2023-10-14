using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.Users;

namespace Iconic.Domain.Entitites.Discussions
{
    public class Message
    {
        public int MediaId { get; set; }
        public Attachment Media { get; set; }
        public string Content { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public int? UserId { get; set; }
        public User Freelancer { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}