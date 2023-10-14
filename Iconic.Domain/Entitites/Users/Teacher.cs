using Iconic.Domain.Entitites.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.Users
{
    public class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? ImageId { get; set; }
        public Attachment Image { get; set; }
        public int? ResumeId { get; set; }
        public Attachment Resume { get; set; }
    }
}
