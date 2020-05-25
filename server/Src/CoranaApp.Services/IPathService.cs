using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface IPathService
    {
        List<PathModel> GetAllPaths();
        List<PathModel> GetPathsByCity(PathSearchModel locationSearch);
    }
}
