
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
        IMapper _mapper;
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


        public async Task<List<PathModel>> GetPathsBySearch(PathSearch locationSearchModel)
        {
            PathSearch locationSearch= _mapper.Map<PathSearch>(locationSearchModel);
            
            List<Path> listOfLocations = new List<Path>();
           

            if(locationSearchModel.City != null)
            {
                listOfLocations = await _pathRepository.GetPathsByCity(locationSearch);

            }

            else  if (locationSearchModel.DateStart != null && locationSearchModel.DateEnd != null)
                listOfLocations = await _pathRepository.GetPathsByDate(locationSearch);

           else if (locationSearchModel.DateStart != null)
                listOfLocations = await _pathRepository.GetPathsByStartDate(locationSearch);

          else  if (locationSearchModel.DateEnd != null)
                listOfLocations = await _pathRepository.GetPathsByEndDate(locationSearch);

            if (listOfLocations==null || !listOfLocations.Any())
                return null;
            return _mapper.Map<List<PathModel>>(listOfLocations);
        }
    }
}
