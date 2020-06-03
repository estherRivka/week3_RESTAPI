
using AutoMapper;
using CoronaApp.Entities;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PathService : IPathService
    {
        private IPathRepository _pathRepository;
        private IMapper _mapper;
        public PathService(IMapper mapper,IPathRepository pathRepository)
        {
            _pathRepository = pathRepository;
            _mapper = mapper;
        }

        public async Task<List<PathModel>> GetAllPaths()
        {
             List<Path> paths = await _pathRepository.GetAllPaths();
            //if (paths == null)
            //{
            //    return null;
            //}
            return _mapper.Map<List<PathModel>>(paths);
        }


        public async Task<List<PathModel>> GetPathsBySearch(PathSearch locationSearch)
        {
          
            List<Path> listOfLocations;
           
            if (locationSearch.StartDate != DateTime.MinValue && locationSearch.EndDate!= DateTime.MinValue)
            {
                listOfLocations = await _pathRepository.GetPathsByDate(locationSearch);
            }
            else
            {
                listOfLocations = await _pathRepository.GetPathsByProperty(locationSearch);
            }

            //if (listOfLocations == null || !listOfLocations.Any())
            //{
            //    return null;
            //}

            return _mapper.Map<List<PathModel>>(listOfLocations);
        }
    }
}
