using Iconic.Domain.Commons;
using Iconic.Domain.Entitites.Forums;
using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Forums
{
    public class ForumQuestionForViewDto : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }

        public int UserId { get; set; }

        public bool HasFoundAnswer { get; set; } = false;
        public virtual ICollection<ForumAnswer> Answers { get; set; }
    }
}
