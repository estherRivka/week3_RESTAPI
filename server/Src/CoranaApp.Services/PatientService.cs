
using AutoMapper;
using CoronaApp.Entities;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Routing;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository, IMapper mapper, LinkGenerator linkGenerator )
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<PatientModel> GetById(int id)
        {
            Patient patient = await _patientRepository.GetById(id);
            if (patient == null)
            {
                return null;
            }

            return _mapper.Map<PatientModel>(patient);
        }

        public async Task<List<PatientModel>> GetPatientsByAge(int age)
        {
          List<Patient> patients = await _patientRepository.GetPatientsByAge(age);
            return _mapper.Map<List<PatientModel>>(patients);
        }

        public async Task<PatientModel> Save(PatientModel newPatient)
        {
            Patient patient = await _patientRepository.GetById(newPatient.PatientId);

            if (patient != null)
            {
                return null;
            }

            patient = _mapper.Map<Patient>(newPatient);
            Patient newPatientFromDbs = await _patientRepository.Save(patient);
            Log.Information("Patient Created {@newPatient}", newPatient);

            return _mapper.Map<PatientModel>(newPatientFromDbs);
        }

        public async Task<PatientModel> Update(PatientModel updatedPatient)
        {
            Patient patient = await _patientRepository.GetById(updatedPatient.PatientId);
            if (patient == null)
            {
                return null;
            }
            patient = _mapper.Map<Patient>(updatedPatient);

            Patient updatedPatientFromDbs = await _patientRepository.Update(patient);
            Log.Information("Patient with id {@id} updated {@newPatient}", updatedPatientFromDbs.PatientId, updatedPatientFromDbs);
            return _mapper.Map<PatientModel>(updatedPatientFromDbs);

        }

        //ActionResult delete(int id)
        //{
        //    return _patientRepository.Delete(id);
        //}
    }
}

