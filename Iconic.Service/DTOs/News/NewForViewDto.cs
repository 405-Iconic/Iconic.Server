using Iconic.Domain.Entitites.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.News
{
    public class NewForViewDto
    {
        public long Id { get; set; }
        public int BannerId { get; set; }
        public Attachment Banner { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GalleryForViewDto> Galleries { get; set; }
    }
}
