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
        public string Token { get; internal set; }
        public string UserName { get; internal set; }
        //public string Password { get; internal set; }
        //public string Name { get; internal set; }


    }
}