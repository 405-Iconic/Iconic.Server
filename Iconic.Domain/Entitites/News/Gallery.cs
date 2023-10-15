using Iconic.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.News
{
    public class Gallery : Auditable
    {
        public int AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
        public int NewsId { get; set; }
        public New News { get; set; }
    }
}
