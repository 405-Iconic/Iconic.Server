using Iconic.Domain.Commons;

namespace Iconic.Service.DTOs.Quizzes
{
    public class AnswerForViewDto : Auditable
    {
        public string Content { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}