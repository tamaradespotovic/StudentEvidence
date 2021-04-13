using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentEvidence.Models
{
    public class StudentModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Broj indexa je obavezno polje!")]
        public int BrIndexa { get; set; }


        [Required(ErrorMessage = "Ime je obavezno polje!")]
        public string Ime { get; set; }


        [Required(ErrorMessage = "Prezime je obavezno polje!")]
        public string Prezime { get; set; }


        [Required(ErrorMessage = "Grad je obavezno polje!")]
        public string Grad { get; set; }
    }
}