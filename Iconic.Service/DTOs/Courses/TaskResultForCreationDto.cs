using Iconic.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.DTOs.Courses
{
    public class TaskResultForCreationDto
    {
        [Required]
        public int TaskId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required,Range(0, 100)]
        public int Score { get; set; }
    }
}
