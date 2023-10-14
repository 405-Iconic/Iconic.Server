using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Courses;
using Iconic.Service.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Users
{
    public class TeacherForViewDto : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Attachment Image { get; set; }
        public Attachment Resume { get; set; }
        public ICollection<CourseForViewDto> Courses { get; set; }
    }
}
