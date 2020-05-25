using CoronaApp.Models;
using CoronaApp.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface IPatientRepository
    {
        Patient GetById(int id);

        void Update(Patient patient);
        void Save(Patient newPatient);
        //void Delete(int id);
    }
}
