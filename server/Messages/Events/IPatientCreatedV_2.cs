using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Events
{
    public interface IPatientCreatedV_2 : IPatientCreated
    {
        string FullName { get; set; }
    }
}
