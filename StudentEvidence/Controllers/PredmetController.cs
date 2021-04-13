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
    public class PredmetController : Controller
    {
        DALIspit dalIspit = new DALIspit();
        DALPredmet dalPredmet = new DALPredmet();
        DALStudent dalStudent = new DALStudent();
        // GET: Predmet
        public ActionResult Index()
        {

            var allPredmets = dalPredmet.getAllPredmet();
            List<PredmetModel> model = new List<PredmetModel>();
            foreach (var item in allPredmets)
            {
                model.Add(new PredmetModel()
                {
                    ID = item.ID,
                   Naziv=item.Naziv

                });
            }
            return View(model);
        }
        public ActionResult EditPredmet(int ID)
        {
            var predmet = dalPredmet.getPredmet(ID);
            return View(new PredmetModel() { Naziv=predmet.Naziv,ID=predmet.ID});
        }
        [HttpPost]
        public ActionResult EditPredmet(PredmetModel model)
        {
            if (ModelState.IsValid) { 
                dalPredmet.EditPredmet(new Predmet() { Naziv = model.Naziv, ID = model.ID });
                return RedirectToAction("Index", "Predmet");
            }
            ModelState.AddModelError("Naziv", "Naziv is required.");
            return RedirectToAction("EditPredmet", "Predmet",new { ID= model.ID }); 
            

        }
        public ActionResult AddPredmet() {
            return View();
        }
        [HttpPost]
        public ActionResult AddPredmet(PredmetModel model)
        {
            if (ModelState.IsValid)
            {
                dalPredmet.AddPredmet(new Predmet() {
                    Naziv = model.Naziv });
                    return RedirectToAction("Index", "Predmet");
            }
            return View(); 

        }
        public ActionResult DeletePredmet(int ID)
        {

            dalPredmet.DeletePredmet(ID);
            return RedirectToAction("Index", "Predmet");


        }
    }
}