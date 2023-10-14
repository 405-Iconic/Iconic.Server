using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;

namespace Iconic.Domain.Entities.Quizes
{
    public class Question : Auditable
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public int? AttachmentId { get; set; }
        public Attachment Attachment { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public Level Level { get; set; }
    }
}
