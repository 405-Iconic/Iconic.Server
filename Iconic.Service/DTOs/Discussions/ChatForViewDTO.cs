using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Discussions;
using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Discussions
{
    public class ChatForViewDTO : Auditable
    {
        public int UserId { get; set; }
        public int TeacherId { get; set; }
        public virtual ICollection<MessageForViewDto> Messages { get; set; }
    }
}
