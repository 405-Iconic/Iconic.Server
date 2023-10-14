using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Courses
{
    public class VideoForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public int Length { get; set; }
        public int ViewCount { get; set; }
        public string Url { get; set; }
        public int LessonId { get; set; }
    }
}
