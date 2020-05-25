using CoronaApp.Services.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface IPatientService
    {
        PatientModel GetById(int id);
        PatientModel Save(PatientModel newPatient);
        PatientModel Update(PatientModel updatedPatient);
         //Delete(int id);
    }
}
