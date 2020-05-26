using System.Collections.Generic;

namespace CoronaApp.Entities

{
    public class Patient
    {
        public int Id { get; set; }
        public List<Path> Paths { get; set; }
    }
}