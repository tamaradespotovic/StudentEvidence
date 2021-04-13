using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class DALStudent
    {
        StudentEvidenceEntities _db = new StudentEvidenceEntities();
        public List<Student> getAllStudent()
        {
            return _db.Students.ToList();
        }
        public Student getStudent(int ID)
        {
            var student = _db.Students.FirstOrDefault(x => x.ID == ID);
            

            return student;
        }
        public void UpdateStudent(Student model)
        {
            var student = _db.Students.FirstOrDefault(x => x.ID == model.ID);
            student.Grad = model.Grad;
            student.Ime = model.Ime;
            student.Prezime = model.Prezime;
            student.BrIndexa = model.BrIndexa;
            _db.SaveChanges();
        }
        public void DeleteStudent(int ID)
        {
            var student = _db.Students.FirstOrDefault(x => x.ID == ID);
            _db.Students.Remove(student);
            _db.SaveChanges();
        }
        public void AddStudent(Student model)
        {
            _db.Students.Add(model);
            _db.SaveChanges();
        }

    }
}
