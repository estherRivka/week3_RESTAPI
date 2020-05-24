using CoronaApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api
{
    public interface IPatientService
    {
        PatientModel GetById(int id);

        void Update(PatientModel patient);
    }
}
