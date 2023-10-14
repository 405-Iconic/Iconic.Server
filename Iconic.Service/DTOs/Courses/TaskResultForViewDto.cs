using Iconic.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Courses
{
    public class TaskResultForViewDto : Auditable
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
    }
}
