using CoronaApp.Entities;
using CoronaApp.Services;
//using CoronaApp.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class PathRepository : IPathRepository
    {
        private readonly CoronaContext _dbcontext;
        public PathRepository(CoronaContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpGet]
        public async Task<List<Path>> GetAllPaths()
        {

            List<Path> paths = await _dbcontext.Paths.ToListAsync();
             //  List<Path> paths = DataFormat.GetAllPaths();
             return paths;
        }

        [HttpGet("{locationSearch}")]
        public async Task<List<Path>> GetPathsByCity([FromQuery] PathSearch locationSearch)
        {
             List<Path> paths = await _dbcontext.Paths.ToListAsync();
            //List<Path> paths = DataFormat.GetAllPaths();
            if (paths == null || !paths.Any())
                return null;
                    //throw new Exception("couldnt find any paths!");
             //  List<Path> PathsInCity = paths.FindAll(path => path.City == locationSearch.City);
            List<Path> PathsInCity =await _dbcontext.Paths.Where(path => path.City == locationSearch.City).ToListAsync();

            if (PathsInCity == null || !PathsInCity.Any())
                // throw new Exception("couldnt find any paths in this city!");
                return null;
                return PathsInCity;
                
           
        }

       
    }
}
