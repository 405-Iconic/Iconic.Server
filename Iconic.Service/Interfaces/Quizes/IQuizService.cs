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
    public interface IQuizService
    {
        Task<QuizForViewDto> CreateAsync(QuizForCreationDto dto);
        Task<QuizForViewDto> UpdateAsync(int id, QuizForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Quiz, bool>> expression);
        Task<IEnumerable<QuizForViewDto>> GetAllAsync();
        Task<QuizForViewDto> GetAsync(Expression<Func<Quiz, bool>> expression);
    }
}
