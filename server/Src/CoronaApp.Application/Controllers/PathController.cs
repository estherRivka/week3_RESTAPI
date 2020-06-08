using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Entities;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<ActionResult<List<PathModel>>> GetAllPaths()
        {
              List<PathModel> paths =await _pathService.GetAllPaths();
               
                //if (paths == null)
                //    return NotFound("Couldn't find any paths");
            Log.Information("successfull to add all paths {@paths}", paths);
           
                return paths;
          
        }
        [EnableCors]
        [HttpGet]

        public async Task<ActionResult<List<PathModel>>> GetPathSearchBy([FromQuery]PathSearch pathSearch)
        {
                List<PathModel> paths = await _pathService.GetPathsBySearch(pathSearch);

            if (paths == null)
            {
            //    Log.Warning("Couldn't find any paths in city {@pathSearchByCity}", pathSearch.City);
               throw new Exception($"Couldn't find any paths for search {pathSearch.searchByProperty}");
            }
            Log.Information("succesfull to get paths in city {@pathSearchByCity}", paths);
         

            return paths;
          
        }






    }
}
