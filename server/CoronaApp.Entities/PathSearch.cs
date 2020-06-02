using System;

namespace CoronaApp.Entities
{
    public class PathSearch
    {
        public SearchBy searchByProperty { get; set; }
        public string City { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public int Age { get; set; }

    }
}