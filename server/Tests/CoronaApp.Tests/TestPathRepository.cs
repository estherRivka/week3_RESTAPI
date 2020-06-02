using CoronaApp.Dal;
using CoronaApp.Entities;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Tests
{
    public class TestPathRepository : IPathRepository
    {
        private readonly CoronaContext _dbContext;
        public TestPathRepository(CoronaContext dbContext)
        {
            _dbContext = dbContext;
        } 
        public   Task<List<Path>> GetAllPaths()
        {
            return Task.FromResult<List<Path>>(new List<Path>() { new Path() { Id = 1, City = "Tel Aviv", Location = "Library", StartDate = new DateTime(2000, 12, 01), EndDate = new DateTime(2000, 12, 30) } }
                  ); ;

        //  return  _dbContext.Paths.ToList();
                 
                }

        public Task<List<Path>> GetPathsByAge(PathSearch locationSearch)
        {
            throw new NotImplementedException();
        }

        public Task<List<Path>> GetPathsByCity(PathSearch locationSearch)
        {
            throw new NotImplementedException();
        }

        public Task<List<Path>> GetPathsByDate(PathSearch locationSearch)
        {
            throw new NotImplementedException();
        }

        public Task<List<Path>> GetPathsByEndDate(PathSearch locationSearch)
        {
            throw new NotImplementedException();
        }

        public Task<List<Path>> GetPathsByProperty(PathSearch locationSearch)
        {
            throw new NotImplementedException();
        }

        public Task<List<Path>> GetPathsByStartDate(PathSearch locationSearch)
        {
            throw new NotImplementedException();
        }
    }
}
