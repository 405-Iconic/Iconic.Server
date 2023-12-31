﻿using Iconic.Domain.Entities.Quizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Quizzes
{
    public class QuizResultForCreationDto
    {
        public int QuizId { get; set; }
        public int UserId { get; set; }
        public ICollection<SolvedQuestionForCreationDTO> SolvedQuestions { get; set; }
    }
}
