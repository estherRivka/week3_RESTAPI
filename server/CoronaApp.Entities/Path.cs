using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaApp.Entities
{
    public class Path
    {
       // [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int PatientId { get; set; }
    }
}