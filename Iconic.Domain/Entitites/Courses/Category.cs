using Iconic.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.Courses
{
    public class Category : Auditable
    {
        public string Title { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
