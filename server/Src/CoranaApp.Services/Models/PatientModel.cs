using System.Collections.Generic;

namespace CoronaApp.Services.Models
{
    public class PatientModel
    {
        public int PatientId { get; set; }
        public List<PathModel> Paths { get; set; }
    }
}