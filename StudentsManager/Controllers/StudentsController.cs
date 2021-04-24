using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using StudentsManager.Models;

namespace StudentsManager.Controllers
{
    public class StudentsController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,Name,Surname,GroupId,Course,Grade")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,Name,Surname,GroupId,Course,Grade")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void GetStudents()
        {
            var allStudents = db.Students.ToList<Student>();
            ViewBag.Students = allStudents;
        }

        // GET: Sum
        public ActionResult GradeSum()
        {
            var sum = 0;
            GetStudents();

            foreach (var item in db.Students)
            {
                sum += item.Grade;
            }
            ViewBag.sum = sum;
            return View();
        }

        public ActionResult Rank()
        {
            ViewBag.Best = db.Students.ToList<Student>().OrderByDescending(s => s.Grade).Take(5);
            ViewBag.Worst = db.Students.ToList<Student>().OrderBy(s => s.Grade).Take(5);
            return View();
        }

        public FileStreamResult CreateFile()
        {
            var students = "Output string: ";
            foreach (var item in db.Students)
            {
                students += item.Name + " " + item.Surname + ", Group number: " + item.GroupId +
                    ", Course name: " + item.Course + ",Student`s grade: " + item.Grade + Environment.NewLine;
            }
            var byteArray = Encoding.UTF8.GetBytes(students);
            var output = new MemoryStream(byteArray);
            return File(output, "text/plain", "Students list.txt");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}