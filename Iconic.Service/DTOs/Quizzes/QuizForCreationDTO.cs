using Iconic.Domain.Entities.Quizes;
using Iconic.Domain.Entitites.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Quizzes
{
    public class QuizForCreationDTO
    {
        public int LessonId { get; set; }
        public bool IsFirstQuiz { get; set; }
        public string Title { get; set; }

        public int TimeToSolveInMinutes { get; set; }
    }
}
