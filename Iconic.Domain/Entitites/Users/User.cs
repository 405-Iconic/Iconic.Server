using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.Users
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? ImageId { get; set; }
        public Attachment Image { get; set; }
        public byte TotalScore { get; set; }
        public int CompletedWorks { get; set; }
        public UserRole Role { get; set; }
    }
}
