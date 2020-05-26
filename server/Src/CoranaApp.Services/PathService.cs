
using AutoMapper;
using CoronaApp.Entities;
using CoronaApp.Services.Models;
//using CoronaApp.Models;
//using CoronaApp.Services.Entities;
//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PathService : IPathService
    {
        private IPathRepository _pathRepository;
        IMapper _mapper;
        public PathService(IMapper mapper,IPathRepository pathRepository)
        {
            _pathRepository = pathRepository;
            _mapper = mapper;
        }

     
     

        public async Task<List<PathModel>> GetAllPaths()
        {
            List<Path> paths=await _pathRepository.GetAllPaths();
            if (paths == null)
                return null;
            return _mapper.Map<List<PathModel>>(paths);
        }


        public async Task<List<PathModel>> GetPathsByCity(PathSearchModel locationSearchModel)
        {
            PathSearch locationSearch= _mapper.Map<PathSearch>(locationSearchModel);
           List<Path> listOfLocations=await _pathRepository.GetPathsByCity(locationSearch);
            if (listOfLocations == null)
                return null;
            return _mapper.Map<List<PathModel>>(listOfLocations);
        }
    }
}
