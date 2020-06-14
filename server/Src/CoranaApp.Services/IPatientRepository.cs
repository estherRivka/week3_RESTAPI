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
         Task<List<Patient>> GetPatientsByAge(int age);
        Task<Patient> getByUserNameAndPassword(string username, string password);
        Task<string> GetUserName(int id);

        //void Delete(int id);
    }
}
