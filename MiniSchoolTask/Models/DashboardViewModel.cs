using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniSchoolTask.Models
{
    public class DashboardViewModel
    {
        public List<Class> Classes { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}