﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Courses
{
    public class CourseForCreationDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public string CategoryId { get; set; }
        public AttachmentForCreationDto File { get; set; }
    }
}
