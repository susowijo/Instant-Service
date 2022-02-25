using InstantService.API.BL.Users;
using Microsoft.Extensions.DependencyInjection;

namespace InstantService.API.BL
{
    /// <summary>
    /// 
    /// </summary>
    public static class BlDiContainer
    {
        #region Extensions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlScoped(this IServiceCollection services)
        {
            // context di
            services.AddScoped<IUserBl, UserBl>();

            return services;
        }

        #endregion
    }
}