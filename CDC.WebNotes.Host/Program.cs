using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WebNotes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHostBuilder hostBuilder = CreateHostBuilder(args);

            hostBuilder.Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);

            AddSerilogLogger();

            hostBuilder
                .ConfigureAppConfiguration(ConfigureAppConfigurations)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

            return hostBuilder;
        }

        private static void AddSerilogLogger()
        {
            Log.Logger = new LoggerConfiguration()
             .Enrich.FromLogContext()
             .WriteTo.Console()
             .CreateLogger();

            Log.Information("Logger run successfully");
        }

        /// <summary>
        /// Method to Add app configuration from some configuration service
        /// </summary>
        /// <param name="context"> Some data from context: example HostingEnvironment </param>
        /// <param name="builder"></param>
        private static void ConfigureAppConfigurations(HostBuilderContext context, IConfigurationBuilder builder)
        {
            //TODO Add configuration to app here

            //IConfigurationRoot configuration = builder.Build();
            //string connection = configuration.GetConnectionString("ConfigurationsConnection");
            //if (string.IsNullOrWhiteSpace(connection))
            //    return;
        }
    }
}
