
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
            if (paths == null)
            {
                return null;
            }
            return _mapper.Map<List<PathModel>>(paths);
        }


        public async Task<List<PathModel>> GetPathsBySearch(PathSearch locationSearch)
        {
            // PathSearch locationSearch= _mapper.Map<PathSearch>(locationSearchModel);

            List<Path> listOfLocations = new List<Path>();

             //listOfLocations= await _pathRepository.GetPathsByProperty(locationSearch);
            if (locationSearch.City != null)
            {
                listOfLocations = await _pathRepository.GetPathsByCity(locationSearch);
                  }
            else if (locationSearch.Age != 0)
           {
                listOfLocations = await _pathRepository.GetPathsByAge(locationSearch);

            }
            else if (locationSearch.DateStart != null && locationSearch.DateEnd != null)
            {
             listOfLocations = await _pathRepository.GetPathsByDate(locationSearch);

           }

            else if (locationSearch.DateStart != null)
            {
              listOfLocations = await _pathRepository.GetPathsByStartDate(locationSearch);

           }

           else if (locationSearch.DateEnd != null)
            {
               listOfLocations = await _pathRepository.GetPathsByEndDate(locationSearch);

            }

            if (listOfLocations == null || !listOfLocations.Any())
            {
                return null;
            }

            return _mapper.Map<List<PathModel>>(listOfLocations);
        }
    }
}
