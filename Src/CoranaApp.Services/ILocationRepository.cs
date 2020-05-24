using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface ILocationRepository
    {
        ICollection<Path> Get(LocationSearch locationSearch);
    }
}
