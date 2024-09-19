using MiniSchoolTask.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MiniSchoolTask.Controllers
{
    public class AuthController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var teacher = new Teachers
                {
                    TeacherName = model.FullName,
                    TeacherEmail = model.Email,
                    TeacherPassword = model.Password // Store it hashed in a real app
                };

                db.Teachers.Add(teacher);
                db.SaveChanges();

                return RedirectToAction("Login");
            }

            // If the model state is invalid, return the same view with the error messages
            return View(model);
        }


        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(Login loginModel)
        {
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == loginModel.Email && t.TeacherPassword == loginModel.Password);
            if (teacher != null)
            {
                Session["TeacherId"] = teacher.TeacherId;
                Session["TeacherName"] = teacher.TeacherName;
                return RedirectToAction("Dashboard", "Home");
            }
            ModelState.AddModelError("", "Invalid email or password.");
            return View(loginModel);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}