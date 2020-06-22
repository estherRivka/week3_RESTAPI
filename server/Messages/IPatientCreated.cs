using NServiceBus;

namespace Messages
{
    public interface IPatientCreated : IEvent
    {
         int PatientId { get; set; }
    }
}