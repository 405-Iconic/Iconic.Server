using Iconic.Domain.Commons;
using Iconic.Domain.Entities.Quizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.Courses
{
    public class Lesson : Auditable
    {
        // make an html view
        public string Documentation { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int AttachmentId { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
