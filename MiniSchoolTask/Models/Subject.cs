using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniSchoolTask.Models
{
    public class Subject
    {
       
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Details { get; set; }

        public int ClassId { get; set; } 
        public virtual Class Class { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
