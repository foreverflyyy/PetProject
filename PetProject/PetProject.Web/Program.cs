using Microsoft.AspNetCore;
using NLog.Web;

namespace PetProject.Web
{
    /// <summary>
    /// Entry point class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }


        /// <summary>
        /// Создание билдера для WebHost
        /// </summary>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(options =>
                {
                    options.AddJsonFile("settings.json", optional: false, reloadOnChange: false);
                    options.AddCommandLine(args);
                })
                .CaptureStartupErrors(true)
                .UseStartup<Startup>().UseKestrel(options =>
                {
                    options.Limits.MaxRequestBodySize = 51 * 1024 * 1024; //51MB
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();
        }
    }
}
