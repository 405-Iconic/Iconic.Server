using Iconic.Domain.Entities.Quizes;
using Iconic.Domain.Entitites.s;
using Iconic.Service.DTOs.Quizzes;
using Iconic.Service.DTOs.s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Quizes
{
    internal interface IQuestionService
    {
        Task<QuestionForViewDto> CreateAsync(QuestionForCreationDto dto);
        Task<QuestionForViewDto> UpdateAsync(int id, QuestionForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Question, bool>> expression);
        Task<IEnumerable<QuestionForViewDto>> GetAllAsync();
        Task<QuestionForViewDto> GetAsync(Expression<Func<Question, bool>> expression);
    }
}
