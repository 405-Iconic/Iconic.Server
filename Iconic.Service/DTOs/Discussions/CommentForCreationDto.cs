using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Discussions
{
    public class CommentForCreationDto
    {
        public int LessonId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}
