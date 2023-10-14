using Iconic.Domain.Commons;

namespace Iconic.Domain.Entities.Quizes
{
    public class SolvedQuestion : Auditable
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        public bool IsCorrect { get; set; }
        public int QuizResultId { get; set; }
        public QuizResult QuizResult { get; set; }
    }
}