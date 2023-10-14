using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.Courses
{
    public class Submission
    {
        public class Task : Auditable
        {
            public string Title { get; set; }
            public string Description { get; set; }

            public int AttachmentId { get; set; }
            public Attachment Attachment { get; set; }
            public int UserId { get; set; }
            public User User { get; set; }
        }
    }
}
