
using AutoMapper;
using CoronaApp.Entities;
using CoronaApp.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class PatientRepository : IPatientRepository
    {

        private readonly IMapper _mapper;
        private readonly CoronaContext _dbContext;
        public PatientRepository(IMapper mapper, CoronaContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
       public async Task<Patient> GetByUserNameAndPassword(string username, string password)
        {
            Patient patient= await _dbContext.Patients
                .Where(patient =>
                    patient.UserName == username && patient.Password == password)
                .FirstOrDefaultAsync();
            return patient;
            
        }
        public async Task<Patient> GetById(int id)
        {

            return await _dbContext.Patients      
                .Include(patient => patient.Paths)
                .Where(patient => patient.PatientId == id)
                .FirstOrDefaultAsync();


        }

        public async Task<List<Patient>> GetPatientsByAge(int age)
        {
            List<Patient> patients = await _dbContext.Patients
                 .Where(patient => patient.Age == age)
                 .Include(patient => patient.Paths).ToListAsync();
            return patients;
        }

        public async Task<Patient> Save(Patient newPatient)
        {
            _dbContext.Patients.Add(newPatient);

            await _dbContext.SaveChangesAsync();
            Log.Information("Patient Created {@newPatient}", newPatient);

            return newPatient;
        }
        public async Task<Patient> Update(Patient updatedPatient)
        {
            Patient patientToUpdate = await _dbContext.Patients
                .Where(patient => patient.PatientId == updatedPatient.PatientId)
                .Include(patient => patient.Paths)
                .FirstOrDefaultAsync();


            if (patientToUpdate == null)
            {
                return null;
            }
             _mapper.Map(updatedPatient, patientToUpdate);
            await _dbContext.SaveChangesAsync();
            Log.Information("Patient with id  {@id}", patientToUpdate.PatientId);

            return patientToUpdate;
        }
        //delete()
        //{
        //    Patient patient = patients.Find(patient => patient.Id == id);
        //    if (patient == null)
        //    {
        //        return BadRequest($"patient with id:{id} does not exist");
        //    }

        //    patients.Remove(patient);
        //    return Ok();
        //}
    }
}
