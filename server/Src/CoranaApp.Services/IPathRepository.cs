using CoronaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface IPathRepository
    {
        List<Path> GetAllPaths();
        List<Path> GetPathsByCity(PathSearch locationSearch);
    }
}
