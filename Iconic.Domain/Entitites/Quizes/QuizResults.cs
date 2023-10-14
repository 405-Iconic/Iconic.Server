using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Users;
using System.Collections.Generic;

namespace Iconic.Domain.Entities.Quizes
{
    public class QuizResult : Auditable
    {
        public int CorrectAnswers { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<SolvedQuestion> SolvedQuestions { get; set; }
    }
}
