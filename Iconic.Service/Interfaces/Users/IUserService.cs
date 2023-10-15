using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Users;
using Iconic.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Users;

public interface IUserService
{
    // Authentication
    string CreateToken(string key, string issuer, User user);
    Task<List<UserForViewDto>> GetAll(PaginationParams @params, Expression<Func<User, bool>> predicate = null);
    Task<object> LoginAsync(string email, string password);
    Task<UserForViewDto> GetAsync(Expression<Func<User, bool>> predicate);
    Task<UserForViewDto> CreateAsync(UserForCreationDto userDto);
    Task<bool> DeleteAsync(Expression<Func<User, bool>> predicate);
    Task<UserForViewDto> UpdateAsync(int id, UserForCreationDto userDto);
}