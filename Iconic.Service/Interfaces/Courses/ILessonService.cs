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
    public interface ILessonService
    {
        Task<LessonForViewDto> CreateAsync(LessonForCreationDto dto);
        Task<LessonForViewDto> UpdateAsync(int id, LessonForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Lesson, bool>> expression);
        Task<IEnumerable<LessonForViewDto>> GetAllAsync();
        Task<LessonForViewDto> GetAsync(Expression<Func<Lesson, bool>> expression);
    }
}
