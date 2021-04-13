using DATA;
using StudentEvidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentEvidence.Controllers
{
    [Authorize(Roles = "admin")]
    public class StudentController : Controller
    {
        DALIspit dalIspit = new DALIspit();
        DALPredmet dalPredmet = new DALPredmet();
        DALStudent dalStudent = new DALStudent();
        // GET: Student
        public ActionResult Index()
        {
            var allStudents=dalStudent.getAllStudent();
            List<StudentModel> model = new List<StudentModel>();
            foreach (var item in allStudents)
            {
                model.Add(new StudentModel()
                {
                    ID = item.ID,
                    BrIndexa = item.BrIndexa,
                    Grad = item.Grad,
                    Ime = item.Ime,
                    Prezime = item.Prezime

                });
            }
            return View(model);
        }
        public ActionResult EditStudent(int ID)
        {

            var dataModel=dalStudent.getStudent(ID);
            return View(new StudentModel() { 
                ID=dataModel.ID,
                BrIndexa=dataModel.BrIndexa,
                Grad=dataModel.Grad,
                Ime=dataModel.Ime,
                Prezime=dataModel.Prezime
            });


        }
        [HttpPost]
        public ActionResult EditStudent(StudentModel model)
        {

            if (ModelState.IsValid) {
                dalStudent.UpdateStudent(new Student()
                {
                    Grad = model.Grad,
                    BrIndexa = model.BrIndexa,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    ID = model.ID
                });
                return RedirectToAction("Index", "Student");
            }
            return RedirectToAction("EditStudent", "Student", new { ID = model.ID });


        }
        public ActionResult DeleteStudent(int ID)
        {

            dalStudent.DeleteStudent(ID);
            return RedirectToAction("Index", "Student");


        }
        public ActionResult AddStudent()
        {

             
            return View();


        }
        [HttpPost]
        public ActionResult AddStudent(StudentModel model)
        {
            if (ModelState.IsValid) {
                dalStudent.AddStudent(new Student()
                {
                    BrIndexa = model.BrIndexa,
                    Grad = model.Grad,
                    Ime = model.Ime,
                    Prezime = model.Prezime
                });

                return RedirectToAction("Index", "Student");
            }
            return View();


        }
    }
}