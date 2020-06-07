using CoronaApp.Services.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IPatientService
    {
        Task<PatientModel> GetById(int id);
        Task<PatientModel> Save(PatientModel newPatient);
        Task<PatientModel> Update(PatientModel updatedPatient);
        Task<List<PatientModel>> GetPatientsByAge(int age);
        Task<string> AuthenticateAsync(string username, string password);
        //Delete(int id);
    }
}
