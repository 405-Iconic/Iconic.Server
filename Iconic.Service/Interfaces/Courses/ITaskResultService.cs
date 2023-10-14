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
    public interface ITaskResultService
    {
        Task<TaskResultForViewDto> CreateAsync(TaskResultForCreationDto dto);
        Task<TaskResultForViewDto> UpdateAsync(int id, TaskResultForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<TaskResult, bool>> expression);
        Task<IEnumerable<TaskResultForViewDto>> GetAllAsync();
        Task<TaskResultForViewDto> GetAsync(Expression<Func<TaskResult, bool>> expression);
    }
}
