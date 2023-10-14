using Iconic.Domain.Entitites.Discussions;
using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Discussions
{
    public class MessageForCreationDto
    {
        public int? MediaId { get; set; }
        public string Content { get; set; }
        public int ChatId { get; set; }
        public int? UserId { get; set; }
        public int? TeacherId { get; set; }
    }
}
