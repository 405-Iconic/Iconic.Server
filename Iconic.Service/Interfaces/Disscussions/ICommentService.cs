using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.Discussions;
using Iconic.Service.DTOs.Courses;
using Iconic.Service.DTOs.Discussions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Disscussions
{
    public interface ICommentService
    {
        Task<CommentForViewDto> CreateAsync(CommentForCreationDto dto);
        Task<CommentForViewDto> UpdateAsync(int id, CommentForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Comment, bool>> expression);
        Task<IEnumerable<CommentForViewDto>> GetAllAsync();
        Task<CommentForViewDto> GetAsync(Expression<Func<Comment, bool>> expression);
    }
}
