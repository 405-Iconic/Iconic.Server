using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Courses
{
    public class AttachmentForCreationDto
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public Stream Stream { get; set; }
    }
}
