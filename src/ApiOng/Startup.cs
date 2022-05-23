using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using AM.Amil.PeNaAreia.CrossCutting;

namespace Whp.MaisTopV2.Api
{
    public class Startup : NativeInjector
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
    }
}
