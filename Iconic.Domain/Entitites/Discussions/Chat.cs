using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.Discussions
{
    public class Chat : Auditable
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TeaxherId { get; set; }
        public Teacher Teacher { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
