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

        public int ClassId { get; set; }  // Foreign Key for Class
        public virtual Class Class { get; set; }  // Navigation Property for Class

        
        public virtual ICollection<Tasks> Tasks { get; set; }  // No semicolon after the declaration
    }
}
