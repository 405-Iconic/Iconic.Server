using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Courses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Iconic.Domain.Entities.Quizes
{
    public class Quiz : Auditable
    {
        public int NumberOfQuestions { get; set; }
        public long LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public bool isFirstQuiz { get; set; }
        public string Title { get; set; }

        public ICollection<Question> Questions { get; set; }
        public int TimeToSolveInMinutes { get; set; }
    }
}
