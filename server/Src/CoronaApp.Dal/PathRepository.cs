
using CoronaApp.Entities;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoronaApp.Dal
{
    public class PathRepository : IPathRepository
    {
        private readonly CoronaContext _dbcontext;
        public PathRepository(CoronaContext dbContext)
        {
            _dbcontext = dbContext;
        }
      
        public async Task<List<Path>> GetAllPaths()
        {

            List<Path> paths = await _dbcontext.Paths.ToListAsync();
            Log.Information("access to database was succesfull ,got data:{@paths}", paths);
             return paths;
        }


        public async Task<List<Path>> GetPathsByProperty(PathSearch locationSearch)
        {
            Path path = new Path();

            PropertyInfo info = path
                .GetType()
                .GetProperty(locationSearch.searchByProperty.ToString());
            PropertyInfo info1 = locationSearch
                .GetType()
                .GetProperty(locationSearch.searchByProperty.ToString());
           
            List<Path> PathsInPropery = await _dbcontext.Paths.ToListAsync();
            for (int i = 0; i < PathsInPropery.Count(); i++)
            {
                if (string.Compare(info.GetValue(PathsInPropery[i]).ToString(), info1.GetValue(locationSearch).ToString()) == 0)

                    PathsInPropery.Add(PathsInPropery[i]);
            }

            //List<Path> PathsInPropery1 = PathsInPropery.Where(path => info
            // .GetValue(path) == info1
            // .GetValue(locationSearch))
            //    .ToList();
            //List <Path> PathsInPropery = await _dbcontext.Paths
            // .Where(path => info
            //     .GetValue(path) == info
            //     .GetValue(locationSearch))
            //      .ToListAsync();

            return PathsInPropery;
        }
        public async Task<List<Path>> GetPathsByAge(PathSearch locationSearch)
        {

            List<Path> paths = await _dbcontext.Paths.Include(p => p.Patient)
                .Where(path => path.Patient.Age == locationSearch.Age)
                .ToListAsync();

            return paths;


        }
        public async Task<List<Path>> GetPathsByCity( PathSearch locationSearch)
        {
             List<Path> paths = await _dbcontext.Paths.ToListAsync();
           
            if (paths == null || !paths.Any())
                return null;
                
            List<Path> PathsInCity =await _dbcontext.Paths.Where(path => path.City == locationSearch.City).ToListAsync();

            if (PathsInCity == null || !PathsInCity.Any())
                
                return null;
                return PathsInCity;
                
           
        }
        public async Task<List<Path>> GetPathsByDate(PathSearch locationSearch)
        {
            List<Path> paths = await _dbcontext.Paths.ToListAsync();

            if (paths == null || !paths.Any())
                return null;
         
            List<Path> PathsInDate = await _dbcontext.Paths.Where(path => path.StartDate > locationSearch.DateStart && path.EndDate < locationSearch.DateEnd).ToListAsync();
          
            if (PathsInDate == null || !PathsInDate.Any())
                return null;
            return PathsInDate;


        }

        public async Task<List<Path>> GetPathsByStartDate(PathSearch locationSearch)
        {
            List<Path> paths = await _dbcontext.Paths.ToListAsync();

            if (!paths.Any())
                return null;
            //throw new Exception("couldnt find any paths!");
            //  DateTime.ParseExact(strDate, "dd/MM/YYYY", CultureInfo.InvariantCulture)
            // DateTime.ParseExact(m.StartDate, "dd/mm/yyyy", null)
            List<Path> PathsInDate =await _dbcontext.Paths.Where(path => path.StartDate > locationSearch.DateStart ).ToListAsync();

            if (PathsInDate == null || !PathsInDate.Any())
                // throw new Exception("couldnt find any paths in this city!");
                return null;
            return PathsInDate;


        }
        public async Task<List<Path>> GetPathsByEndDate(PathSearch locationSearch)
        {
            List<Path> paths = await _dbcontext.Paths.ToListAsync();

            if (!paths.Any())
                return null;
            //throw new Exception("couldnt find any paths!");
            //  DateTime.ParseExact(strDate, "dd/MM/YYYY", CultureInfo.InvariantCulture)
            List<Path> PathsInDate =await _dbcontext.Paths.Where(path => path.EndDate <locationSearch.DateEnd).ToListAsync();

            if (PathsInDate == null || !PathsInDate.Any())
                // throw new Exception("couldnt find any paths in this city!");
                return null;
            return PathsInDate;


        }
    }
}
