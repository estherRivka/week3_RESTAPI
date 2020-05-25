using CoronaApp.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface IPathRepository
    {
        ICollection<Path> Get(LocationSearch locationSearch);
    }
}
