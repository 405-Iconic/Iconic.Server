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
    public interface ISubmissionService
    {
        Task<SubmissionForViewDto> CreateAsync(SubmissionForCreationDto dto);
        Task<IEnumerable<SubmissionForViewDto>> GetAllAsync();
        Task<SubmissionForViewDto> GetAsync(Expression<Func<Submission, bool>> expression);
    }
}
