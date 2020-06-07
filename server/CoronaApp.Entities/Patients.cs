using System;
using System.Collections.Generic;

namespace CoronaApp.Entities
{
    public partial class Patients
    {
        public Patients()
        {
            Paths = new HashSet<Paths>();
        }

        public int PatientId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<Paths> Paths { get; set; }
    }
}
