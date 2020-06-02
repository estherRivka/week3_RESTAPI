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
using Serilog;

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

        [Route("[action]/{age:int}")]
        [EnableCors]
        [HttpGet] 
        public async Task<ActionResult<List<PatientModel>>> GetPatientsByAge(int age)
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

        // POST: api/Path
        [HttpPost]
        public async Task<ActionResult<PatientModel>> Save(PatientModel newPatient)
        {

                PatientModel patient =  await _patientService.Save(newPatient);
                if (patient == null)
                {
                    Log.Information("Patient with id {@id} requested to create but already exists", newPatient.PatientId);
                //throw new Exception("Patient with id ${ newPatient.PatientId } requested to create but already exists");

                    return BadRequest($"patient with id:{newPatient.PatientId} already exists");
                }

              var newPatientURI =  Url.Action(action: "GetById", values: new { id = newPatient.PatientId });


                if (string.IsNullOrWhiteSpace(newPatientURI))
                {
                    Log.Information("requested new patient id {@id} is not a valid id", newPatient.PatientId);

                    throw new Exception("BadRequest Could not use current patientId");
                }
                return Created(newPatientURI, patient); ;


        }


        // PUT: api/Patient
        [HttpPut]
        public async Task<ActionResult<PatientModel>> Update(PatientModel updatedPatient)
        {

                PatientModel patient =  await _patientService.Update(updatedPatient);
                if (patient == null)
                {
                    Log.Error("Patient with id {@id} requested to update was not found", updatedPatient.PatientId);

                    return BadRequest($"patient with id:{updatedPatient.PatientId} was not found");
                }

                return await _patientService.Update(updatedPatient);
            


        }

        // DELETE: api/Patient/7
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {

                // return _patientService.Delete(id);
                return Ok();





        }



    }
}
