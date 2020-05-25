
using AutoMapper;
using CoronaApp.Models;
using CoronaApp.Services.Entities;
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
            _patientRepository.Save(_mapper.Map<Patient>(newPatient));
            return newPatient;

        }
        public PatientModel Update(PatientModel updatedPatient)
        {
            Patient patient = _patientRepository.GetById(updatedPatient.PatientId);
            if (patient == null)
            {
                return null;
            }
            patient = _mapper.Map<Patient>(updatedPatient);
            _patientRepository.Update(patient);
            return _mapper.Map<PatientModel>(patient);

        }

        //ActionResult delete(int id)
        //{
        //    return _patientRepository.Delete(id);
        //}
    }
}

