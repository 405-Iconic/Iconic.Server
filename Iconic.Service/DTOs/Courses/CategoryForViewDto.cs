using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Courses
{
    public class CategoryForViewDto : Auditable
    {
        public string Title { get; set; }
        public ICollection<CourseForViewDto> Courses { get; set; }
    }
}
