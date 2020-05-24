using CoronaApp.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface IPatientRepository
    {
        Patient GetById(string id);

        void Update(Patient patient);
    }
}
