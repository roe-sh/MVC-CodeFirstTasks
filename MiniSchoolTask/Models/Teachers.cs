using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniSchoolTask.Models
{
    public class Teachers
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherPassword { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
