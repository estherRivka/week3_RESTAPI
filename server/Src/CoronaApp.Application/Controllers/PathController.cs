using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Services;
using CoronaApp.Services.Models;
//using EntitiesTemp;
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
        public async Task<ActionResult<List<PathModel>>> Get()
        {

            try
            {
                List<PathModel> paths =await _pathService.GetAllPaths();
               
                if (paths == null)
                    return NotFound("Couldn't find any paths");
                return paths;
            }
            catch (Exception)
            {
                // return e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Paths");
            }
        }

        //[HttpGet("{pathSearch}")]
        [HttpGet]
        [Route("[action]")]

        public async Task<ActionResult<List<PathModel>>> GetPathSearchBy([FromQuery]PathSearchModel pathSearchModel=null)
        {
             
            try
            {
                List<PathModel> paths=await  _pathService.GetPathsByCity(pathSearchModel);
                
                if (paths == null)
                    // return NotFound($"Couldn't find any paths in city {pathSearchModel.City}");
                    return NotFound($"Couldn't find any paths in city {pathSearchModel.City}");
                return paths;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Paths");
            }
        }






    }
}
