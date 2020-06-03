﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Api.Exceptions;
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

            throw new Exception("Not Found: patients with requested age were not found");

            PatientModel patient = await _patientService.GetById(id);
            if (patient == null)
            {
                throw new PatientNotExistExcption(id);
            }
            else
            {

                return patient;
            }
            // return patient;



        }
        //api/patient/getbyid/id
        [Route("[action]/{age:int}")]
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<List<PatientModel>>> GetPatientsByAge([Range(18, 120)]int age)
        {


            List<PatientModel> patients = await _patientService.GetPatientsByAge(age);
            if (patients == null)
            {
                throw new Exception("Not Found: patients with requested age were not found");
            }
            else
            {
                return patients;
            }
            //return patients;



        }

        // POST: api/Path
        [HttpPost]
        
        public async Task<ActionResult<PatientModel>> Save(PatientModel newPatient)
        {

            PatientModel patient = await _patientService.Save(newPatient);
            if (patient == null)
            {
                Log.Information("Patient with id {@id} requested to create but already exists", newPatient.PatientId);
                throw new Exception("Bad Request: Patient with id ${ newPatient.PatientId } requested to create but already exists");
                //   throw new HttpResponseException(HttpStatusCode.NotFound);
                // return BadRequest($"patient with id:{newPatient.PatientId} already exists");
            }

            var newPatientURI = Url.Action(action: "GetById", values: new { id = newPatient.PatientId });


            if (string.IsNullOrWhiteSpace(newPatientURI))
            {
                throw new Exception("BadRequest: Could not create Patient with current patientId");
            }
            else
            {
                return Created(newPatientURI, patient); ;
            }


        }


        // PUT: api/Patient
        [HttpPut]
        public async Task<ActionResult<PatientModel>> Update(PatientModel updatedPatient)
        {

            PatientModel patient = await _patientService.Update(updatedPatient);
            if (patient == null)
            {
                throw new PatientNotExistExcption(updatedPatient.PatientId);
                //  return BadRequest($"patient with id:{updatedPatient.PatientId} was not found");
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
