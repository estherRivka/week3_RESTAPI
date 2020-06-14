using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoronaApp.Services.Models
{/// <summary>
/// patient model
/// </summary>
    public class PatientModel
    {
     /// <summary>
     /// id of the patient
     /// </summary>
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