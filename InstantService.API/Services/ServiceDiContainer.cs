using InstantService.API.Services.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace InstantService.API.Services
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceDiContainer
    {
        #region Extensions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceScoped(this IServiceCollection services)
        {
            services.AddTransient<IUtilService, UtilService>();
            
            // add yours
            
            return services;
        }

        #endregion
    }
}