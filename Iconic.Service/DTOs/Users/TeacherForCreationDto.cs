using Iconic.Domain.Entitites.Courses;
using Iconic.Service.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Users
{
    public class TeacherForCreationDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public AttachmentForCreationDto Resume { get; set; }
        public AttachmentForCreationDto Image { get; set; }
    }
}
