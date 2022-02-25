using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace InstantService.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var env = InstantService.API.Services.Utils.Environments.Current.ToString();
                    webBuilder
                        .UseEnvironment(env)
                        .UseStartup<Startup>()
                        .UseKestrel(options =>
                        {
                            options.Limits.MaxRequestBodySize = int.MaxValue;
                        });
                    //.UseUrls("http://localhost:7174"); 
                });
    }
}