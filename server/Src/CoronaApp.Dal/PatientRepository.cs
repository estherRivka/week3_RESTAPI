
using AutoMapper;
using CoronaApp.Entities;
using CoronaApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class PatientRepository : IPatientRepository
    {
        //private static List<Patient> patients = new List<Patient>() {
        //    new Patient() { Id = 1, Paths = new List<Path>() {
        //        new Path(){ City = "Jerusalem", StartDate = new DateTime(2019, 12, 08), EndDate = new DateTime(2019, 12, 09), Location = "Library" },
        //        new Path() { City = "Jafa", StartDate = new DateTime(2019, 10, 10), EndDate = new DateTime(2019, 10, 11), Location = "Library" },
        //        new Path() { City = "Tzfat", StartDate = new DateTime(2018, 03, 02), EndDate = new DateTime(2018, 03, 05), Location = "Library" }
        //        },

        //    },
        //    new Patient() { Id = 2, Paths = new List<Path>() {
        //        new Path() { City = "Tel Aviv", StartDate = new DateTime(2018, 12, 08), EndDate = new DateTime(2018, 12, 01), Location = "Library" },
        //        new Path() { City = "Tiberias", StartDate = new DateTime(2020, 10, 12), EndDate = new DateTime(2020, 10, 11), Location = "Library" }

        //        }
        //    }

        //};
        private readonly IMapper _mapper;
        private readonly CoronaContext _dbContext;
        public PatientRepository(IMapper mapper, CoronaContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

       public async Task<Patient> GetById(int id)
        {
            //    Patient patient = patients
            //       .Find(patient => patient.Id == id);
            //    return patient;
            //return await  _dbContext.Patients
            //      .Where(patient => patient.PatientId == id)
            //      .Include(patient=> patient.Paths)
            //      .FirstOrDefaultAsync();

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
          //  _dbContext.("SET IDENTITY_INSERT [dbo].[MyUser] ON");
            await  _dbContext.SaveChangesAsync();
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
