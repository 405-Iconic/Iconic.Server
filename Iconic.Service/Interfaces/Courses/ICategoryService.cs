using Iconic.Domain.Entitites.Courses;
using Iconic.Service.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Courses
{
    public interface ICategoryService
    {
        Task<CategoryForViewDto> CreateAsync(CategoryForCreationDto dto);
        Task<CategoryForViewDto> UpdateAsync(int id, CategoryForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression);
        Task<IEnumerable<CategoryForViewDto>> GetAllAsync();
        Task<CategoryForViewDto> GetAsync(Expression<Func<Category,bool>> expression);
    }
}
