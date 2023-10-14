using Iconic.Domain.Entities.Quizes;
using Iconic.Domain.Entitites.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Quizzes
{
    public class QuestionForCreationDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public int QuizId { get; set; }
        public int? AttachmentId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
