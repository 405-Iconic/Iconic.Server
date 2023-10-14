using Iconic.Domain.Commons;

namespace Iconic.Domain.Entities.Quizes
{
    public class SolvedQuestion : Auditable
    {
        public long QuestionId { get; set; }
        public Question Question { get; set; }
        public long AnswerId { get; set; }
        public Answer Answer { get; set; }
        public bool IsCorrect { get; set; }
        public long QuizResultId { get; set; }
        public QuizResult QuizResult { get; set; }
    }
}
