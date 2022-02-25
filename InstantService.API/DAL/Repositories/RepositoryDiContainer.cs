using InstantService.API.DAL.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace InstantService.API.DAL.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public static class RepositoryDiContainer
    {
        #region Extensions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositoryScoped(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            
            return services;
        }

        #endregion
    }
}