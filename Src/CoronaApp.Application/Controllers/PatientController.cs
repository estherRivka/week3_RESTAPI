using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Api.Models;
//using CoronaApp.Services.Models;
//using CoronaApp.Services.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using CoronaApp.Services.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly static List<Patient> patients = new List<Patient>() {
            new Patient() { Id = 1, Paths = new List<Path>() {
                new Path(){ City = "Jerusalem", StartDate = new DateTime(2019, 12, 08), EndDate = new DateTime(2019, 12, 09), Location = "Library" },
                new Path() { City = "Jafa", StartDate = new DateTime(2019, 10, 10), EndDate = new DateTime(2019, 10, 11), Location = "Library" },
                new Path() { City = "Tzfat", StartDate = new DateTime(2018, 03, 02), EndDate = new DateTime(2018, 03, 05), Location = "Library" }
                },

            },
            new Patient() { Id = 2, Paths = new List<Path>() {
                new Path() { City = "Tel Aviv", StartDate = new DateTime(2018, 12, 08), EndDate = new DateTime(2018, 12, 01), Location = "Library" },
                new Path() { City = "Tiberias", StartDate = new DateTime(2020, 10, 12), EndDate = new DateTime(2020, 10, 11), Location = "Library" }

                }
            }

        };


        // GET api/<PatientController>/5
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public PatientController(IMapper mapper, LinkGenerator linkGenerator)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }



        [EnableCors]
        // GET: api/Path/5
        [HttpGet("{id:int}")]
        public ActionResult<PatientModel> Get(int id)
        {
            try
            {
                Patient patient = patients
                    .Find(patient => patient.Id == id);

                if (patient == null)
                {
                    return NotFound($"patient with id:{id} was not found");
                }
                return _mapper.Map<PatientModel>(patient);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while retrieving patient");
            }

        }

        // POST: api/Path
        [HttpPost]
        public ActionResult<Patient> Post(PatientModel newPatient)
        {
            try
            {
                bool exists = patients
                    .Exists(patient => patient.Id == newPatient.PatientId);
                if (exists == true)
                {
                    return BadRequest($"patient with id:{newPatient.PatientId} already exists");
                }

                var newPatientURI = _linkGenerator.GetPathByAction(HttpContext,
                  "Get",
                  values: new { id = newPatient.PatientId });

                if (string.IsNullOrWhiteSpace(newPatientURI))
                {
                    return BadRequest("Could not use current patientId");
                }

                // Create a new Camp
                Patient patient = _mapper.Map<Patient>(newPatient);
                patients.Add(patient);

                return Created(newPatientURI, _mapper.Map<Patient>(patient));


            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while creating new patient");
            }

        }


        // PUT: api/Path/5
        [HttpPut]
        public ActionResult<PatientModel> Put(PatientModel updatedPatient)
        {
            try
            {
                Patient patientToUpdate = patients
                    .Find(patient => patient.Id == updatedPatient.PatientId);

                DateTime x = DateTime.ParseExact(updatedPatient.Paths[0].StartDate, "dd/mm/yyyy", null);
                if (patientToUpdate == null)
                {
                    return NotFound($"patient with id:{updatedPatient.PatientId} was not found");
                }
                _mapper.Map(updatedPatient, patientToUpdate);
                return _mapper.Map<PatientModel>(patientToUpdate);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while retrieving patient");
            }


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Patient patient = patients.Find(patient => patient.Id == id);
                if (patient == null)
                {
                    return BadRequest($"patient with id:{id} does not exist");
                }

                patients.Remove(patient);
                return Ok();
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while deleting patient");
            }

        }



    }
}
