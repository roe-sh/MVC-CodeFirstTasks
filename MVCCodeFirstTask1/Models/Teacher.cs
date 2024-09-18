using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCodeFirstTask1.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public virtual Classes Classes { get; set; }

    }
}