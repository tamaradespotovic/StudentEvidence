using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class DALPredmet
    {
        StudentEvidenceEntities _db = new StudentEvidenceEntities();
        public List<Predmet> getAllPredmet()
        {
            return _db.Predmets.ToList();
        }
        public Predmet getPredmet(int ID)
        {
            return _db.Predmets.FirstOrDefault(x=>x.ID==ID);
        }
        public void AddPredmet(Predmet model) {
            _db.Predmets.Add(model);
            _db.SaveChanges();
        }
        public void EditPredmet(Predmet model) {
            var predmet = _db.Predmets.FirstOrDefault(x => x.ID == model.ID);
            predmet.Naziv = model.Naziv; 
            _db.SaveChanges();
        }
        public void DeletePredmet(int ID) {
            var predmet = _db.Predmets.FirstOrDefault(x => x.ID == ID); 
            _db.Predmets.Remove(predmet);
            _db.SaveChanges();
        }

    }
}
