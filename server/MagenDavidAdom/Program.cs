using NServiceBus;
using System;
using System.Threading.Tasks;

namespace MagenDavidAdom
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "MagenDavidAdom";

            var endpointConfiguration = new EndpointConfiguration("MagenDavidAdom");

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
