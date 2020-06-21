using NServiceBus;

namespace Messages
{
    public class PatientCreated : IEvent
    {
        public int PatientId { get; set; }
    }
}