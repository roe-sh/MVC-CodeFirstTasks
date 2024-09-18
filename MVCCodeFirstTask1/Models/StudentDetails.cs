using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCodeFirstTask1.Models
{
    public class StudentDetails
    {
        [Key]
        public int StudentDetailsID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int StudentID { get; set; }

        public virtual Student Student { get; set; }
    }
}