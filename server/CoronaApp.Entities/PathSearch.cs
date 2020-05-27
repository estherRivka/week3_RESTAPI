using System;

namespace CoronaApp.Entities
{
    public class PathSearch
    {
        public SearchBy searchByProperty { get; set; }
        public string City { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateStart { get; set; }
        public int Age { get; set; }

    }
}