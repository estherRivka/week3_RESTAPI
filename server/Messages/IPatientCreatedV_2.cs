using System;
using System.Collections.Generic;
using System.Text;

namespace Messages
{
    public interface IPatientCreatedV_2 : IPatientCreated
    {
        string FullName { get; set; }
    }
}

