using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoronaApp.Services.Models
{
    public class PatientModel
    {
     
        public int PatientId { get; set; }
        public List<PathModel> Paths { get; set; }

     //   [Range(18,120)]
        public int Age { get; set; }
        public string UserName { get; set; }
     //   public string Name { get; set; }

        //[JsonIgnore]
        public string Password { get; set; }
    }
}