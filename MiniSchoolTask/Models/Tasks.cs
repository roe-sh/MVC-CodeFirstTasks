using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniSchoolTask.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task name is required")]
        [StringLength(100, ErrorMessage = "Task name cannot be longer than 100 characters.")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Task details are required")]
        public string TaskDetails { get; set; }

        [Required(ErrorMessage = "Enroll date is required")]
        [DataType(DataType.Date)]
        public DateTime EnrollDate { get; set; }


        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
