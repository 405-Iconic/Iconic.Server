using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.News;
using Iconic.Service.DTOs.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.News
{
    public interface INewsService
    {
        Task<NewForViewDto> CreateAsync(NewForCreationDto provinceForCreationDTO);
        Task<NewForViewDto> UpdateAsync(long id, NewForCreationDto provinceForCreationDTO);
        Task<IEnumerable<NewForViewDto>> GetAll(PaginationParams @params, Expression<Func<New, bool>> expression = null);
        Task<NewForViewDto> GetAsync(Expression<Func<New, bool>> expression);
        Task<bool> DeleteAsync(long id);
    }
}
