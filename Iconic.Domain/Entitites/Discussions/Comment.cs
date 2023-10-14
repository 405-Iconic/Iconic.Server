using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.Discussions
{
    public class Comment : Auditable
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
    }
}
