using Iconic.Domain.Entitites.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.News
{
    public class GalleryForViewDto
    {
        public long Id { get; set; }
        public long AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
        public long NewsId { get; set; }
    }
}
