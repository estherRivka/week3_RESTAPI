
using AutoMapper;
using CoronaApp.Entities;
using CoronaApp.Services;

using System;
using System.Collections.Generic;

namespace CoronaApp.Dal
{
    public class PatientRepository : IPatientRepository
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
        private IMapper _mapper;
        public PatientRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

       public Patient GetById(int id) 
        {
            Patient patient = patients
               .Find(patient => patient.Id == id);
            return patient;
        }
        public void Save(Patient newPatient)
        {
            patients.Add(newPatient); 
        }
        public void Update(Patient updatedPatient)
        {
            Patient patientToUpdate = patients
                        .Find(patient => patient.Id == updatedPatient.Id);

            
            if (patientToUpdate == null)
            {
                return;
            }
            _mapper.Map(updatedPatient, patientToUpdate);

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
