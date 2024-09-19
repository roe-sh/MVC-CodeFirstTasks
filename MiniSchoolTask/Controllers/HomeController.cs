using MiniSchoolTask.Models;
using System.Linq;
using System.Web.Mvc;

namespace MiniSchoolTask.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();
        
        // GET:
        
        public ActionResult Dashboard()
        {
            if (Session["TeacherId"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Get the classes and subjects associated with the logged-in teacher
            var teacherId = (int)Session["TeacherId"];
            var classes = db.Classs.Where(c => c.TeacherId == teacherId).ToList();
            var subjects = db.Subjects.Where(s => s.Class.TeacherId == teacherId).ToList();

            var dashboardViewModel = new DashboardViewModel
            {
                Classes = classes,
                Subjects = subjects
            };

            return View(dashboardViewModel);
        }

        // GET: ClassDetails
        public ActionResult ClassDetails(int id)
        {
            var classDetails = db.Classs.Include("Students").FirstOrDefault(c => c.ClassId == id);
            return View(classDetails);
        }

        // GET: SubjectDetails
        public ActionResult SubjectDetails(int id)
        {
            var subjectDetails = db.Subjects.Include("Tasks").FirstOrDefault(s => s.SubjectId == id);
            return View(subjectDetails);
        }
    
public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        

        // GET: Account/Login
    }

}
