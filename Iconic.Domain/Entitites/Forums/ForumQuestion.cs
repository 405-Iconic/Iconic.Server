using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.Forums
{
    public class ForumQuestion
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public bool HasFoundAnswer { get; set; } = false;
        public virtual ICollection<ForumAnswer> Answers { get; set; }
    }
}
