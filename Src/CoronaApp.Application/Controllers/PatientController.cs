using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Services;


//using CoronaApp.Services.Models;
//using CoronaApp.Services.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        // GET api/<PatientController>/5
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;
        private readonly LinkGenerator _linkGenerator;
        public PatientController(IMapper mapper, LinkGenerator linkGenerator, IPatientService patientService)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _patientService = patientService;

        }
    }
}



       // [EnableCors]
        // GET: api/Path/5
      //  [HttpGet("{id:int}")]
        //public ActionResult<PatientModel> Get(int id)
        //{
        //    try
        //    {

        //        return _patientService.GetById(id);
               
        //    }
        //    catch (Exception e)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while retrieving patient");
        //    }

        //}

        //// POST: api/Path
        //[HttpPost]
        //public ActionResult<PatientModel> Post(PatientModel newPatient)
        //{
        //    try
        //    {
        //        bool exists = patients
        //            .Exists(patient => patient.Id == newPatient.PatientId);
        //        if (exists == true)
        //        {
        //            return BadRequest($"patient with id:{newPatient.PatientId} already exists");
        //        }

        //        var newPatientURI = _linkGenerator.GetPathByAction(HttpContext,
        //          "Get",
        //          values: new { id = newPatient.PatientId });

        //        if (string.IsNullOrWhiteSpace(newPatientURI))
        //        {
        //            return BadRequest("Could not use current patientId");
        //        }

        //        // Create a new Camp
        //        Patient patient = _mapper.Map<Patient>(newPatient);
        //        patients.Add(patient);

        //        return Created(newPatientURI, _mapper.Map<Patient>(patient));


        //    }
        //    catch (Exception)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while creating new patient");
        //    }

        //}


        //// PUT: api/Path/5
        //[HttpPut]
        //public ActionResult<PatientModel> Put(PatientModel updatedPatient)
        //{
        //    try
        //    {
        //        Patient patientToUpdate = patients
        //            .Find(patient => patient.Id == updatedPatient.PatientId);

        //        DateTime x = DateTime.ParseExact(updatedPatient.Paths[0].StartDate, "dd/mm/yyyy", null);
        //        if (patientToUpdate == null)
        //        {
        //            return NotFound($"patient with id:{updatedPatient.PatientId} was not found");
        //        }
        //        _mapper.Map(updatedPatient, patientToUpdate);
        //        return _mapper.Map<PatientModel>(patientToUpdate);
        //    }
        //    catch (Exception e)
        //    {

        //        return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while retrieving patient");
        //    }


        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id:int}")]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        Patient patient = patients.Find(patient => patient.Id == id);
        //        if (patient == null)
        //        {
        //            return BadRequest($"patient with id:{id} does not exist");
        //        }

        //        patients.Remove(patient);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {

        //        return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while deleting patient");
        //    }

        //}



   // }
//}
