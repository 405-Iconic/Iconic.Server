using Iconic.Domain.Entitites.Forums;
using Iconic.Service.DTOs.Forums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Forums
{
    public interface IForumAnswerService
    {
        Task<ForumAnswerForViewDto> CreateAsync(ForumAnswerForCreationDto dto);
        Task<ForumAnswerForViewDto> UpdateAsync(int id, ForumAnswerForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<ForumAnswer, bool>> expression);
        Task<IEnumerable<ForumAnswerForViewDto>> GetAllAsync();
        Task<ForumAnswerForViewDto> GetAsync(Expression<Func<ForumAnswer, bool>> expression);
    }
}
