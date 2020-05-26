
using AutoMapper;
using CoronaApp.Entities;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

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

        public PatientModel GetById(int id)
        {
            Patient patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                return null;
            }

            return _mapper.Map<PatientModel>(patient);
        }

        public PatientModel Save(PatientModel newPatient)
        {
            Patient patient = _patientRepository.GetById(newPatient.PatientId);

            if (patient != null)
            {
                return null;
            }

            patient = _mapper.Map<Patient>(newPatient);
            foreach (var path in patient.Paths)
            {
                path.PatientId = patient.Id;
            }
            Patient newPatientFromDbs = _patientRepository.Save(patient);
            return _mapper.Map<PatientModel>(newPatientFromDbs);
        }

        public PatientModel Update(PatientModel updatedPatient)
        {
            Patient patient = _patientRepository.GetById(updatedPatient.PatientId);
            if (patient == null)
            {
                return null;
            }
            patient = _mapper.Map<Patient>(updatedPatient);
            foreach (var path in patient.Paths)
            {
                path.PatientId = patient.Id;
            }

            Patient updatedPatientFromDbs = _patientRepository.Update(patient);
            return _mapper.Map<PatientModel>(updatedPatientFromDbs);

        }

        //ActionResult delete(int id)
        //{
        //    return _patientRepository.Delete(id);
        //}
    }
}

