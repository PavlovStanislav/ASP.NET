using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsManager.Models;

namespace StudentsManager.Controllers
{
    public class HomeController : Controller
    {
        private StudentContext db = new StudentContext();

        public ActionResult Index()
        {
            GetStudent();
            return View();
        }

        private void GetStudent()
        {
            var allStudents = db.Students.ToList<Student>();
            ViewBag.Students = allStudents;
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            GetStudent();
            var allStudents = db.Students.ToList<Student>();
            ViewBag.Students = allStudents;
            return View();
        }

        [HttpPost]
        public string CreateStudent(Student newStudent)
        {
            db.Students.Add(newStudent);
            db.SaveChanges();
            return "<b>" + newStudent.Surname + "</b>, new student added.";
        }
    }
}