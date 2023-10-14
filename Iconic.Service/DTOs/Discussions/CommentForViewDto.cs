using Iconic.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Discussions
{
    public class CommentForViewDto : Auditable
    {
        public int LessonId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}
