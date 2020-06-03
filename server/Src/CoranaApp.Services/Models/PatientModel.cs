using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Services.Models
{
    public class PatientModel
    {
        [Required]
        public int PatientId { get; set; }
        public List<PathModel> Paths { get; set; }

     //   [Range(18,120)]
        public int Age { get; set; }
    }
}