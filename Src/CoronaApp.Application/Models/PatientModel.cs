using System.Collections.Generic;

namespace CoronaApp.Api.Models
{
    public class PatientModel
    {
        public int PatientId { get; set; }
        public List<PathModel> Paths { get; set; }
    }
}