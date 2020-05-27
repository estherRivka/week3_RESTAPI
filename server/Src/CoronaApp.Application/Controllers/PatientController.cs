using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;


namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        
        private readonly IPatientService _patientService;
        private readonly LinkGenerator _linkGenerator;
        public PatientController(IPatientService patientService, LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
            _patientService = patientService;

        }

        // GET api/Patient/7
        [Route("[action]/{id:int}")]
        [EnableCors]     
        [HttpGet]
        public async Task<ActionResult<PatientModel>> GetById(int id)
        {
            try
            {        
                PatientModel patient = await _patientService.GetById(id);
                //if (patient == null)
                //{
                //    return NotFound($"patient with id:{id} was not found");
                //}
                //else
                //{
                //    return patient;
                //}
                return patient;
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while retrieving patient" + e.StackTrace);
            }

        }

        [Route("[action]/{age:int}")]
        [EnableCors]
        [HttpGet] 
        public async Task<ActionResult<List<PatientModel>>> GetPatientsByAge(int age)
        {
            try
            {
                List<PatientModel> patients = await _patientService.GetPatientsByAge(age);
                //if (patient == null)
                //{
                //    return NotFound($"patient with id:{id} was not found");
                //}
                //else
                //{
                //    return patient;
                //}
                return patients;
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while retrieving patient" + e.StackTrace);
            }

        }

        // POST: api/Path
        [HttpPost]
        public async Task<ActionResult<PatientModel>> Save(PatientModel newPatient)
        {
            try
            {
                PatientModel patient =  await _patientService.Save(newPatient);
                if (patient == null)
                {
                    return BadRequest($"patient with id:{newPatient.PatientId} already exists");
                }

              var newPatientURI =  Url.Action(action: "GetById", values: new { id = newPatient.PatientId });


                if (string.IsNullOrWhiteSpace(newPatientURI))
                {
                    throw new Exception("BadRequest Could not use current patientId");
                }
                return Created(newPatientURI, patient); ;
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while creating new patient" + e.StackTrace);
            }

        }


        // PUT: api/Patient
        [HttpPut]
        public async Task<ActionResult<PatientModel>> Update(PatientModel updatedPatient)
        {
            try
            {
                PatientModel patient =  await _patientService.Update(updatedPatient);
                if (patient == null)
                {
                    return BadRequest($"patient with id:{updatedPatient.PatientId} was not found");
                }

                return await _patientService.Update(updatedPatient);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while retrieving patient" + e.StackTrace);
            }


        }

        // DELETE: api/Patient/7
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                // return _patientService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure while deleting patient"+e.StackTrace);
            }

        }



    }
}
