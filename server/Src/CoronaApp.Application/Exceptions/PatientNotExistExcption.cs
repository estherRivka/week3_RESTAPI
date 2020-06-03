using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api.Exceptions
{
    public class PatientNotExistExcption : Exception
    {
        public PatientNotExistExcption() 
        {

        }
        public PatientNotExistExcption(int patientId) : base($"Patient with id:{patientId} does not exist")
        {

        }
    }
}
