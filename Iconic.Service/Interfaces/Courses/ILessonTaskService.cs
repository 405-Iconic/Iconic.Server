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
    public interface ILessonTaskService
    {
        Task<LessonTaskForViewDto> CreateAsync(LessonTaskForCreationDto dto);
        Task<LessonTaskForViewDto> UpdateAsync(int id, LessonTaskForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<LessonTask, bool>> expression);
        Task<IEnumerable<LessonTaskForViewDto>> GetAllAsync();
        Task<LessonTaskForViewDto> GetAsync(Expression<Func<LessonTask, bool>> expression);
    }
}
