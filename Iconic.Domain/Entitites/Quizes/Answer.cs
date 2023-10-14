using Iconic.Domain.Commons;

namespace Iconic.Domain.Entities.Quizes
{
    public class Answer : Auditable
    {
        public string Content { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
