using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoronaApp.Entities

{
    public class Patient
    {
        //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientId { get; set; }
        public List<Path> Paths { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}