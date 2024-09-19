using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniSchoolTask.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; } 
        public int StudentAge { get; set; }
        public int ClassId { get; set; } 
        public virtual Class Class { get; set; }
    }
}
