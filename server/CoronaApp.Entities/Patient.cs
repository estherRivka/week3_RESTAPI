using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaApp.Entities

{
    public class Patient
    {
        //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientId { get; set; }
        public List<Path> Paths { get; set; }
        public int Age { get; set; }
    }
}