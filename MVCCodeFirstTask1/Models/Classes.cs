using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCodeFirstTask1.Models
{
    public class Classes
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public virtual Teacher Teacher { get; set; }

    }
}