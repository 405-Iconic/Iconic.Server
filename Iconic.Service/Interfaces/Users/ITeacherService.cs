using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Users;
using Iconic.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Teachers
{
    public interface ITeacherService
    {
        string CreateToken(string key, string issuer, Teacher Teacher);
        object GetAll(PaginationParams @params, Expression<Func<Teacher, bool>> predicate = null);
        Task<object> LoginAsync(string email, string password);
        Task<TeacherForViewDto> GetAsync(Expression<Func<Teacher, bool>> predicate);
        Task<TeacherForViewDto> CreateAsync(TeacherForCreationDto TeacherDto);
        Task<bool> DeleteAsync(Expression<Func<Teacher, bool>> predicate);
        Task<TeacherForViewDto> UpdateAsync(long id, TeacherForCreationDto TeacherDto);
    }
}
