using Iconic.Domain.Entitites.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Courses
{
    public class LessonForCreationDto
    {
        [Required]
        public string Documentation { get; set; }
        [Required]
        public int CourseId { get; set; }
        public int? AttachmentId { get; set; }
    }
}
