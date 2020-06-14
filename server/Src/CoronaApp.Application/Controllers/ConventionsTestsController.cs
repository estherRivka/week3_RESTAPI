using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    /// <summary>
    /// this is a version api
    /// </summary>
    [ApiController]

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class ConventionsTestsController : ControllerBase
    {
        // GET: api/<ConventionsTestsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConventionsTestsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConventionsTestsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConventionsTestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConventionsTestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
