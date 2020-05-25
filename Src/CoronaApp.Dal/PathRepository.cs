using CoronaApp.Services;
using CoronaApp.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal
{
    public class PathRepository : IPathRepository
    {
        public ICollection<Path> Get(LocationSearch locationSearch)
        {
            throw new NotImplementedException();
        }
    }
}
