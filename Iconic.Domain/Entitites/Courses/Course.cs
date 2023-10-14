using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.Courses
{
    public class Course : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
