
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
            if (paths == null ) 
            {
              //  Log.Warning("Couldn't find any paths");
                throw new Exception("NotFound:Couldn't find any paths");

            }
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
           
            List<Path> pathsInPropery = await _dbcontext.Paths.ToListAsync();
            if (pathsInPropery == null )
            {
              //  Log.Warning("Couldn't find any paths");
                throw new Exception("NotFound:Couldn't find any paths");

            }
            List<Path> newPathsInPropery=new List<Path>();
            for (int i = 0; i < pathsInPropery.Count(); i++)
            {
                if (string.Compare(info.GetValue(pathsInPropery[i]).ToString(), info1.GetValue(locationSearch).ToString()) == 0)

                    newPathsInPropery.Add(pathsInPropery[i]);
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
            if (newPathsInPropery == null)
            {
              //  Log.Warning("Couldn't find any paths in property {@pathSearchByCity}", locationSearch.searchByProperty);
                throw new Exception($"NotFound:Couldn't find any paths for property {locationSearch.searchByProperty}");

            }
            return newPathsInPropery;
        }
        //public async Task<List<Path>> GetPathsByAge(PathSearch locationSearch)
        //{

        //    List<Path> paths = await _dbcontext.Paths.Include(p => p.Patient)
        //        .Where(path => path.Patient.Age == locationSearch.Age)
        //        .ToListAsync();
        //    if (paths == null ||)
        //    {
        //        Log.Warning("Couldn't find any paths in city {@pathSearchByCity}", locationSearch.City);
        //        throw new Exception($"NotFound:Couldn't find any paths in {locationSearch.City}");

        //    }
        //    return paths;


        //}
        //public async Task<List<Path>> GetPathsByCity( PathSearch locationSearch)
        //{
        //     List<Path> paths = await _dbcontext.Paths.ToListAsync();

        //    //if (paths == null|| !paths.Any())
        //    //    return null;
        //    if (paths == null  )
        //    {
        //        Log.Warning("Couldn't find any paths in city {@pathSearchByCity}", locationSearch.City);
        //        throw new Exception($"NotFound:Couldn't find any paths {locationSearch.City}");

        //    }
        //    if (!paths.Any())
        //    {
        //        return paths;

        //    }
        //    List <Path> PathsInCity =await _dbcontext.Paths.Where(path => path.City == locationSearch.City).ToListAsync();

        //    //if (PathsInCity == null || !PathsInCity.Any())

        //    //    return null;

        //    if (paths == null )
        //    {
        //        Log.Warning("Couldn't find any paths in city {@pathSearchByCity}", locationSearch.City);
        //        throw new Exception($"NotFound:Couldn't find any paths {locationSearch.City}");

        //    }

        //    return PathsInCity;
                
           
        //}
        public async Task<List<Path>> GetPathsByDate(PathSearch locationSearch)
        {
            List<Path> paths = await _dbcontext.Paths.ToListAsync();

            //if (paths == null || !paths.Any())
            //    return null;
            if (paths == null )
            {
               // Log.Warning("Couldn't find any paths for date from: {@StartDate} till {@EndDate}", locationSearch.StartDate , locationSearch.EndDate);
                throw new Exception($"NotFound:Couldn't find any paths for date from: {locationSearch.StartDate} till {locationSearch.EndDate}");

            }
            if (!paths.Any())
            {
                return paths;
            }
            List<Path> PathsInDate = await _dbcontext.Paths.Where(path => path.StartDate > locationSearch.StartDate && path.EndDate < locationSearch.EndDate).ToListAsync();

            //if (PathsInDate == null || !PathsInDate.Any())
            //    return null;
            if (PathsInDate == null  )
            {
                Log.Warning("Couldn't find any paths between date {@pathSearchByStartDate} and {@pathSearchByEndDate}", locationSearch.StartDate, locationSearch.EndDate);
                throw new Exception($"NotFound:Couldn't find any paths for dates between:{locationSearch.StartDate} till:{locationSearch.EndDate}");

            }

            return PathsInDate;


        }

        //public async Task<List<Path>> GetPathsByStartDate(PathSearch locationSearch)
        //{
        //    List<Path> paths = await _dbcontext.Paths.ToListAsync();

        //    //if (!paths.Any())
        //    //    return null;
        //    if (paths == null  )
        //    {
        //        Log.Warning("Couldn't find any paths !");
        //        throw new Exception("NotFound:Couldn't find any paths");

        //    }
        //    if (!paths.Any())
        //    {
        //        return paths;
        //    }
        //    //throw new Exception("couldnt find any paths!");
        //    //  DateTime.ParseExact(strDate, "dd/MM/YYYY", CultureInfo.InvariantCulture)
        //    // DateTime.ParseExact(m.StartDate, "dd/mm/yyyy", null)
        //    List<Path> PathsInDate =await _dbcontext.Paths.Where(path => path.StartDate > locationSearch.StartDate ).ToListAsync();

        //    if (paths == null || !paths.Any())
        //    {
        //        Log.Warning("Couldn't find any paths in city {@pathSearchByCity}", locationSearch.StartDate);
        //        throw new Exception($"NotFound:Couldn't find any paths for start date: {locationSearch.StartDate}");

        //    }
        //    // return null;
        //    return PathsInDate;


        //}
        //public async Task<List<Path>> GetPathsByEndDate(PathSearch locationSearch)
        //{
        //    List<Path> paths = await _dbcontext.Paths.ToListAsync();

        //    if (paths==null)
        //        throw new Exception("couldnt find any paths!");
        //        if (!paths.Any())
        //        return paths;
        //    //  DateTime.ParseExact(strDate, "dd/MM/YYYY", CultureInfo.InvariantCulture)
        //    List<Path> PathsInDate =await _dbcontext.Paths.Where(path => path.EndDate <locationSearch.EndDate).ToListAsync();

        //    if (PathsInDate == null )
        //    {
        //        Log.Warning("Couldn't find any paths in city {@pathSearchByDate}", locationSearch.EndDate);

        //        throw new Exception($"couldnt find any paths for end date: {locationSearch.EndDate}");
        //    }
                
        //       // return null;
        //    return PathsInDate;


        //}
    }
}
