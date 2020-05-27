using CoronaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IPathRepository
    {
        Task<List<Path>> GetAllPaths();
        Task<List<Path>> GetPathsByCity(PathSearch locationSearch);
        Task<List<Path>> GetPathsByDate(PathSearch locationSearch);

        Task<List<Path>> GetPathsByStartDate(PathSearch locationSearch);

        Task<List<Path>> GetPathsByEndDate(PathSearch locationSearch);
        Task<List<Path>> GetPathsByAge(PathSearch locationSearch);

        


    }
}
