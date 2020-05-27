using System;
using System.Collections.Generic;

namespace tem
{
    public partial class Paths
    {
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int PatientId { get; set; }

        public virtual Patients Patient { get; set; }
    }
}
