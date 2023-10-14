using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Discussions;
using Iconic.Service.DTOs.Discussions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Disscussions
{
    public interface IChatService
    {
        Task<IEnumerable<ChatForViewDto>> GetAll(PaginationParams @params, Expression<Func<Chat, bool>> expression = null);
        Task<ChatForViewDto> GetAsync(Expression<Func<Chat, bool>> expression);
        Task<ChatForViewDto> CreateAsync(ChatForCreationDto chatForCreationDTO);
    }
}
