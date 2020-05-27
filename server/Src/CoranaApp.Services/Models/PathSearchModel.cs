using System;

namespace CoronaApp.Services.Models
{
    public class PathSearchModel
    {
        //enum Season
        //{
        //    City,
        //    DateEnd,
        //    DateStart,
        //    Age
        //}
        public string City { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateStart { get; set; }
        public int Age { get; set; }
    }
}