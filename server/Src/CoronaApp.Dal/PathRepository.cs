using CoronaApp.Entities;
using CoronaApp.Services;
//using CoronaApp.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;



namespace CoronaApp.Dal
{
    public class PathRepository : IPathRepository
    {
        
        [HttpGet]
        public List<Path> GetAllPaths()
        {
            
            
                List<Path> paths = DataFormat.GetAllPaths();
                return paths;
        }

        [HttpGet("{locationSearch}")]
        public List<Path> GetPathsByCity([FromQuery] PathSearch locationSearch)
        {
           
                List<Path> paths = DataFormat.GetAllPaths();
            if (paths == null || !paths.Any())
                return null;
                    //throw new Exception("couldnt find any paths!");
               List<Path> PathsInCity = paths.FindAll(path => path.City == locationSearch.City);
            if (PathsInCity == null || !PathsInCity.Any())
                // throw new Exception("couldnt find any paths in this city!");
                return null;
                return PathsInCity;
                
           
        }

       
    }
}
