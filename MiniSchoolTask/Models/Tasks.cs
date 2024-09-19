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
        public string TaskName { get; set; }
        public string TaskDetails { get; set; }
        public DateTime EnrollDate { get; set; }


        public int SubjectId { get; set; } 
        public virtual Subject Subject { get; set; }
    }
}
