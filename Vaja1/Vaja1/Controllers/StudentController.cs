using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaja1.Models;

namespace Vaja1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var studentList = new List<Student>{
            new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentId = 2, StudentName = "Steve", Age = 21 } ,
            new Student() { StudentId = 3, StudentName = "Bill", Age = 25 } ,
            new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
            new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
            new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
 };

            return View(studentList);
        }
        public ActionResult Edit(int id)
        {
            var studentList = new List<Student>{
            new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentId = 2, StudentName = "Steve", Age = 21 } ,
            new Student() { StudentId = 3, StudentName = "Bill", Age = 25 } ,
            new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
            new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
            new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
 };
            var x = (from a in studentList
                     where a.StudentId == id
                     select a).FirstOrDefault();
            return View(x);
        }
        [HttpPost]public ActionResult Edit([Bind(Include = "StudentId,StudentName,StudentAge")]Student s)
        {
            Student x = s;
            //posodobi bazo

            return RedirectToAction("Index");
        }
    }
}