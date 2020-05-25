//using CoronaApp.Api;
//using CoronaApp.Api.Models;
using CoronaApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public class PatientService : IPatientService
    {

        private IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        //Patient patient = patients
        //   .Find(patient => patient.Id == id);
     
        public PatientModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PatientModel patient)
        {
            throw new NotImplementedException();
        }
    }
}
