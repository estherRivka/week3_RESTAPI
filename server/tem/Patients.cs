using System;
using System.Collections.Generic;

namespace tem
{
    public partial class Patients
    {
        public Patients()
        {
            Paths = new HashSet<Paths>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }

        public virtual ICollection<Paths> Paths { get; set; }
    }
}
