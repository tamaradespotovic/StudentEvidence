//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ispit
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int PredmetID { get; set; }
        public int Ocena { get; set; }
        public System.DateTime DatumPolaganja { get; set; }
    
        public virtual Predmet Predmet { get; set; }
        public virtual Student Student { get; set; }
    }
}