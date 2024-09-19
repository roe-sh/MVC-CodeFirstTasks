using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniSchoolTask.Models
{
    public class Class
    {
        [Key] 
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }

       
        public int TeacherId { get; set; } 
        public virtual Teachers Teacher { get; set; }
    }
}
