using System;
using System.Collections.Generic;

namespace EntitiesTemp
{
    public partial class Patients
    {
        public Patients()
        {
            Paths = new HashSet<Paths>();
        }

        public int Id { get; set; }

        public virtual ICollection<Paths> Paths { get; set; }
    }
}
