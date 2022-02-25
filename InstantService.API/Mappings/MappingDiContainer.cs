using AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace InstantService.API.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public static class MappingDiContainer
    {
        #region Extensions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMappingScoped(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        #endregion
    }
}