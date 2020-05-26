using System;

namespace CoronaApp.Entities
{
    public class Path
    {
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int PatientId { get; set; }
    }
}