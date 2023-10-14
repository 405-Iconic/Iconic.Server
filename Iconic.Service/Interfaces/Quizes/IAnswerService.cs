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
    public interface IAnswerService
    {
        Task<AnswerForViewDto> CreateAsync(AnswerForCreationDto dto);
        Task<AnswerForViewDto> UpdateAsync(int id, AnswerForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Answer, bool>> expression);
        Task<IEnumerable<AnswerForViewDto>> GetAllAsync();
        Task<AnswerForViewDto> GetAsync(Expression<Func<Answer, bool>> expression);
    }
}
