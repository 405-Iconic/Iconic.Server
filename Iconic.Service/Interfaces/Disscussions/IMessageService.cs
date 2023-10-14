using Iconic.Domain.Entitites.Discussions;
using Iconic.Service.DTOs.Discussions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Disscussions
{
    public interface IMessageService
    {
        Task<Message> CreateAsync(MessageForCreationDto dto);
    }
}
