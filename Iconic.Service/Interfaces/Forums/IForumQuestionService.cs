using Iconic.Domain.Entitites.Discussions;
using Iconic.Domain.Entitites.Forums;
using Iconic.Service.DTOs.Discussions;
using Iconic.Service.DTOs.Forums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Forums
{
    public interface IForumQuestionService
    {
        Task<ForumQuestionForViewDto> CreateAsync(ForumQuestionForCreationDto dto);
        Task<ForumQuestionForViewDto> UpdateAsync(int id, ForumQuestionForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<ForumQuestion, bool>> expression);
        Task<IEnumerable<ForumQuestionForViewDto>> GetAllAsync();
        Task<ForumQuestionForViewDto> GetAsync(Expression<Func<ForumQuestion, bool>> expression);
        Task<bool> UserFoundAnswerToQuestion(long questionId);
    }
}
