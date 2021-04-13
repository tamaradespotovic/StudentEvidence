using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentEvidence.Models
{
    public class PredmetModel
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Naziv predmeta je obavezno polje!")]
        public string Naziv { get; set; }
    }
}