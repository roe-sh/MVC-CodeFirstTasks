using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCodeFirstTask1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
         public virtual StudentDetails Details { get; set; }
    }
}