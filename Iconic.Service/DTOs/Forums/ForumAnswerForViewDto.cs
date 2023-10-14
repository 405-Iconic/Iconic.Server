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
    public class ForumAnswerForViewDto : Auditable
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
