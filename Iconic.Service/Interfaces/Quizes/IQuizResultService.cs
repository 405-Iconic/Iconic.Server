using Iconic.Domain.Configurations;
using Iconic.Domain.Entities.Quizes;
using Iconic.Domain.Entitites.Forums;
using Iconic.Service.DTOs.Forums;
using Iconic.Service.DTOs.Quizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Quizes
{
    public interface IQuizResultService
    {
        Task<QuizResultForViewDto> CreateAsync(QuizResultForCreationDto QuizResultForCreationDTO);
        Task<QuizResultForViewDto> StartSolvingQuizAsync(int quizId);
        Task<IEnumerable<QuizResultForViewDto>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<QuizResult, bool>> expression = null);

        Task<QuizResultForViewDto> GetAsync(Expression<Func<QuizResult, bool>> expression);
    }
}
