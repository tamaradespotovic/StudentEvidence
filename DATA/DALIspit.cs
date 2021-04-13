using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    
    public class DALIspit
    {
        StudentEvidenceEntities _db = new StudentEvidenceEntities();
        public List<Ispit> getAllIspit() {
            return _db.Ispits.ToList();
        }
        public Ispit getIspit(int ID)
        {
            return _db.Ispits.FirstOrDefault(x=>x.ID==ID);
        }
        public void UpdateIspit(Ispit model) {
            var ispit = _db.Ispits.FirstOrDefault(x => x.ID == model.ID);
            ispit.Ocena = model.Ocena;
            ispit.PredmetID = model.PredmetID;
            ispit.StudentID = model.StudentID;
            ispit.DatumPolaganja = model.DatumPolaganja;
            _db.SaveChanges();
        }
        public void AddIspit(Ispit model)
        {
            _db.Ispits.Add(model); 
            _db.SaveChanges();
        }
        public void DeleteIspit(int ID)
        {
            var ispit = _db.Ispits.FirstOrDefault(x => x.ID == ID);

            _db.Ispits.Remove(ispit);
            _db.SaveChanges();
        }
    }
}
