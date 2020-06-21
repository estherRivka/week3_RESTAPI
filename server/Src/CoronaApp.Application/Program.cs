using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NServiceBus;
using Serilog;
using Messages.Events;

namespace CoronaApp.Api
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .Build();

        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                 .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Debugger.Break();
            });

            try
            {
                Log.Information("The program has started!!!");

                CreateHostBuilder(args).Build().Run();


            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                /* await endpointInstance.Stop()
                   .ConfigureAwait(false);
                */
                Log.CloseAndFlush();
            }
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseNServiceBus(context =>
            {
                var endpointConfiguration = new EndpointConfiguration("CoronaApp");
                var transport = endpointConfiguration.UseTransport<LearningTransport>();
                var conventions = endpointConfiguration.Conventions();
                conventions.DefiningCommandsAs(type => type.Namespace == "Messages.Commands");
                conventions.DefiningEventsAs(type => type.Namespace == "Messages.Events");

                return endpointConfiguration;
            })
            .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>()
                           .UseConfiguration(Configuration)
                           .UseSerilog();

             });







    }
}



