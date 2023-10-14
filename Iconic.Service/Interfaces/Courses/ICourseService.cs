using Iconic.Domain.Configurations;
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
    public interface ICourseService
    {
        Task<CourseForViewDto> CreateAsync(CourseForCreationDto dto);
        Task<CourseForViewDto> UpdateAsync(int id, CourseForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Course, bool>> expression);
        Task<IEnumerable<CourseForViewDto>> GetAllAsync(PaginationParams @params,
            Expression<Func<Course, bool>> expression,
            string search = null);
        Task<CourseForViewDto> GetAsync(Expression<Func<Course, bool>> expression);
    }
}
