using Iconic.Service.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.News
{
    public class GalleryForCreationDto
    {
        public AttachmentForCreationDto Attachment { get; set; }
        public long NewsId { get; set; }
    }
}
