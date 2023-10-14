using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Courses
{
    public class SubmissionForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AttachmentForCreationDto Attachment { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
    }
}
