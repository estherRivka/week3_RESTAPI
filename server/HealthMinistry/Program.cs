using NServiceBus;
using System;
using System.Threading.Tasks;

namespace HealthMinistry
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "HealthMinistry";

            var endpointConfiguration = new EndpointConfiguration("HealthMinistry");

            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
