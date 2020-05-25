using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Models;
using CoronaApp.Services;

//using AutoMapper;

//using CoronaApp.Services.Models;
//using CoronaApp.Services.Entities;
//using CoronaApp.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {
       

        private readonly IMapper _mapper;
        private readonly IPathService _pathService;
        public PathController(IMapper mapper, IPathService pathService)
        {
            _mapper = mapper;
            _pathService = pathService;

        }

        [EnableCors]
        [HttpGet]
        public ActionResult<List<PathModel>> Get()
        {

            try
            {
                List<PathModel> paths= _pathService.GetAllPaths();
                //List<Path> paths = DataFormat.GetAllPaths();
                //if (paths == null) return NotFound("Couldn't find any paths");
                //// if (!paths.Any()) return BadRequest("Couldn't find any paths");
                //return _mapper.Map<List<PathModel>>(paths);
                if(paths==null)
                    return NotFound("Couldn't find any paths");
                return paths;
            }
            catch (Exception)
            {
               // return e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Paths");
            }
        }


        [HttpGet("{pathSearch}")]
        public ActionResult<List<PathModel>> Get(PathSearchModel pathSearch)
        {
            try
            {
                List<PathModel> paths= _pathService.GetPathsByCity(pathSearch);
                //List<Path> paths = DataFormat.GetAllPaths();
                //if (paths == null || !paths.Any())
                //    return NotFound("Couldn't find any paths");
                //List<Path> PathsInCity = paths.FindAll(path => path.City == city);
                //// if (sortedPath != null && !sortedPath.Any())
                //// return NotFound($"Couldn't find any paths in city {city}");
                //return _mapper.Map<List<PathModel>>(PathsInCity);
                if (paths == null)
                    return NotFound($"Couldn't find any paths in city {pathSearch.City}");
                return paths;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Paths");
            }
        }






    }
}
