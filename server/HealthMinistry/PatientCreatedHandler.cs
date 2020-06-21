using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace HealthMinistry
{
    public class PatientCreatedHandler : IHandleMessages<PatientCreated>
    {
        static ILog log = LogManager.GetLogger<PatientCreated>();
        public Task Handle(PatientCreated message, IMessageHandlerContext context)
        {
            log.Info($"Received PatientCreated, PatientId = {message.PatientId}");

            return Task.CompletedTask;

        }
    }
}
