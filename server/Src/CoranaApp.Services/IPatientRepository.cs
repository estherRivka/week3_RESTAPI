using CoronaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IPatientRepository
    {
        Task<Patient> GetById(int id);

        Task<Patient> Update(Patient patient);
        Task<Patient> Save(Patient newPatient);
        //void Delete(int id);
    }
}
