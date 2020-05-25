
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public class PathService : IPathService
    {
        private IPathRepository _pathRepository;
        public PathService(IPathRepository pathRepository)
        {
            _pathRepository = pathRepository;
        }

        //if (patient == null)
        //{
        //    return NotFound($"patient with id:{id} was not found");
        //}
        //return _mapper.Map<PatientModel>(patient);
        public List<PathModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<PathModel> GetByLocation()
        {
            throw new NotImplementedException();
        }
    }
}
