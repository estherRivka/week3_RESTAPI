using NServiceBus;

namespace Messages.Events
{
    public interface IPatientCreated 
    { 

         int PatientId { get; set; }

    }
}