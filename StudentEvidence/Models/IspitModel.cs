using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentEvidence.Models
{
    public class IspitModel
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "StudentID je obavezno polje!")]
        public int StudentID { get; set; }


        [Required(ErrorMessage = "PredmetID je obavezno polje!")]
        public int PredmetID { get; set; }


        [Required(ErrorMessage = "Ocena je obavezno polje!")]
        public int Ocena { get; set; }


        [Required(ErrorMessage = "Datum polaganja je obavezno polje!")]
        public DateTime DatumPolaganja { get; set; }

        public List<StudentModel> Studenti { get; set; }
        public List<PredmetModel> Predmets { get; set; }
        public StudentModel Student { get; set; }
        public PredmetModel Predmet { get; set; }
    }
}