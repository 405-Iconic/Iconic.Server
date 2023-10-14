using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Courses
{
    public class LessonTaskForViewDto : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Attachment Attachment { get; set; }
        public virtual ICollection<SubmissionForViewDto> Submissions { get; set; }
    }
}
