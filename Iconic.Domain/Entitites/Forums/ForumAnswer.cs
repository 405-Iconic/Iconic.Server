using Iconic.Domain.Entities.Quizes;
using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.Forums
{
    public class ForumAnswer
    {
        public string Text { get; set; }
        public long QuestionId { get; set; }
        public ForumQuestion Question { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
