using MiniSchoolTask.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MiniSchoolTask.Controllers
{
    public class AccountController : Controller
    {
        // Declare DataContext once
        private DataContext db = new DataContext();

        // GET: Account/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        // GET: Account/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // Check if teacher exists with the provided email and password
                var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == model.Email && t.TeacherPassword == model.Password);

                if (teacher != null)
                {
                    // Set authentication cookie and redirect to Home
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If login fails, display an error
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }

            return View(model);
        }

        // GET: Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // Check if the user already exists
                var existingUser = db.Teachers.FirstOrDefault(t => t.TeacherEmail == model.Email);
                if (existingUser == null)
                {
                    // Hash password (optional)
                    var hashedPassword = HashPassword(model.Password);

                    // Create new teacher
                    var teacher = new Teachers
                    {
                        TeacherName = model.FullName,
                        TeacherEmail = model.Email,
                        TeacherPassword = hashedPassword
                    };

                    // Add to the database and save changes
                    db.Teachers.Add(teacher);
                    db.SaveChanges();

                    // Set authentication cookie and redirect to Home
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If email is already registered
                    ModelState.AddModelError("", "This email is already registered.");
                }
            }

            return View(model);
        }

        // GET: Account/Students
        public ActionResult Students()
        {
            var students = db.Students.Include("Class").ToList(); 
            return View(students);
        }

        // GET: Account/Subjects
        public ActionResult Subjects()
        {
            var subjects = db.Subjects.Include("Class").ToList(); 
            return View(subjects);
        }

        // Logout action
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return System.Convert.ToBase64String(hash);
            }
        }
    }
}
