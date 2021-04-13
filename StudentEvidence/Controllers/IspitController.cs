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
    public class IspitController : Controller
    {
        DALIspit dalIspit = new DALIspit();
        DALPredmet dalPredmet = new DALPredmet();
        DALStudent dalStudent = new DALStudent();
        // GET: Ispit
        public ActionResult Index()
        {
            var ispiti = dalIspit.getAllIspit().ToList();
            List<IspitModel> model = new List<IspitModel>();
            foreach (var item in ispiti)
            {
                model.Add(new IspitModel()
                {
                    ID = item.ID,
                    DatumPolaganja = item.DatumPolaganja,
                    Ocena = item.Ocena,
                    Student = new StudentModel() { Ime = item.Student.Ime, Prezime = item.Student.Prezime },
                    Predmet = new PredmetModel() { Naziv = item.Predmet.Naziv }

                });
            }
            return View(model);


        }
        public ActionResult AddIspit()
        {
            var getPredmets = dalPredmet.getAllPredmet();
            var getStudents = dalStudent.getAllStudent();
            List<PredmetModel> predmetModel = new List<PredmetModel>() ;
            List<StudentModel> studentModel = new List<StudentModel>();
            foreach (var item in getPredmets)
            {
                predmetModel.Add(new PredmetModel()
                {
                    ID = item.ID,
                    Naziv = item.Naziv
                });
            }
            foreach (var item in getStudents)
            {
                studentModel.Add(new StudentModel()
                {
                    ID = item.ID,
                    Ime = item.Ime,
                    Prezime = item.Prezime,
                    BrIndexa = item.BrIndexa,
                    Grad = item.Grad
                });
            }
            return View(new IspitModel()
            {
                Studenti = studentModel,
                Predmets = predmetModel
            });
        }
        [HttpPost]
        public ActionResult AddIspit(IspitModel model)
        {
            if (ModelState.IsValid) {
                dalIspit.AddIspit(new Ispit()
                {
                    DatumPolaganja = model.DatumPolaganja,
                    ID = model.ID,
                    Ocena = model.Ocena,
                    PredmetID = model.PredmetID,
                    StudentID = model.StudentID
                });
                return RedirectToAction("Index", "ispit");
            }
            return RedirectToAction("AddIspit", "ispit");
        }
        public ActionResult DeleteIspit(int ID) {
            dalIspit.DeleteIspit(ID);
            return RedirectToAction("Index", "ispit");

        }
        [HttpPost]
        public ActionResult EditIspit(IspitModel model)
        {
            if (ModelState.IsValid) {
                dalIspit.UpdateIspit(new Ispit()
                {
                    DatumPolaganja = model.DatumPolaganja,
                    ID = model.ID,
                    Ocena = model.Ocena,
                    PredmetID = model.PredmetID,
                    StudentID = model.StudentID
                });
                return RedirectToAction("Index", "ispit");
            }

            return RedirectToAction("EditIspit", "ispit", new { ID = model.ID });
        }
        public ActionResult EditIspit(int ID)
        {
            var getPredmets = dalPredmet.getAllPredmet();
            var getStudents = dalStudent.getAllStudent();
            List<PredmetModel> predmetModel = new List<PredmetModel>();
            List<StudentModel> studentModel = new List<StudentModel>();
            foreach (var item in getPredmets)
            {
                predmetModel.Add(new PredmetModel()
                {
                    ID = item.ID,
                    Naziv = item.Naziv
                });
            }
            foreach (var item in getStudents)
            {
                studentModel.Add(new StudentModel()
                {
                    ID = item.ID,
                    Ime = item.Ime,
                    Prezime = item.Prezime,
                    BrIndexa = item.BrIndexa,
                    Grad = item.Grad
                });
            }
            var model = dalIspit.getIspit(ID);
            return View(new IspitModel()
            {
                ID = model.ID,
                DatumPolaganja = model.DatumPolaganja,
                Ocena = model.Ocena,
                Predmet = new PredmetModel() { Naziv = model.Predmet.Naziv },
                Predmets = predmetModel,
                Studenti = studentModel
            }); 
        }
    }
}