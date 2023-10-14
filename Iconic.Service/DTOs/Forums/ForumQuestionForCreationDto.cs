using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Forums
{
    public class ForumQuestionForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public int UserId { get; set; }
    }
}
