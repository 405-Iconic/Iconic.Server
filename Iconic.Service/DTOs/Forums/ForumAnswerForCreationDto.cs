using Iconic.Domain.Entitites.Forums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Forums
{
    public class ForumAnswerForCreationDto
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
