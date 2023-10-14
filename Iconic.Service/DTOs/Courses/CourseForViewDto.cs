using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Courses
{
    public class CourseForViewDto : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int TeacherId { get; set; }
        public Attachment Image { get; set; }
        public virtual ICollection<LessonForViewDto> Lessons { get; set; }
    }
}
