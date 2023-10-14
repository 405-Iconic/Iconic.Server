using Iconic.Domain.Commons;
using Iconic.Domain.Entities.Quizes;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Enums;
using System.Collections.Generic;

namespace Iconic.Service.DTOs.Quizzes
{
    public class QuestionForViewDto : Auditable
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public int QuizId { get; set; }

        public Attachment Attachment { get; set; }

        public ICollection<AnswerForViewDto> Answers { get; set; }
        public Level Level { get; set; }
    }
}