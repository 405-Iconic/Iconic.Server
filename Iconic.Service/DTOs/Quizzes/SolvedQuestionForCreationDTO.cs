using Iconic.Domain.Entities.Quizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Quizzes
{
    public class SolvedQuestionForCreationDTO
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
        public int QuizResultId { get; set; }
    }
}
